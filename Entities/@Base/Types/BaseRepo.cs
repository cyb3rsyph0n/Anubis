using System.Diagnostics;
using Anubis.Entities.Base.Interfaces;
using Anubis.Exceptions;
using Anubis.Helpers.Interfaces.AppSettings;
using Microsoft.EntityFrameworkCore;

namespace Anubis.Entities.Base.Types;

/// <summary>
///     Base repo for entities
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TMapping">Required entity mapping</typeparam>
public abstract class BaseRepo<TEntity, TMapping> : DbContext, IBaseRepo<TEntity> where TEntity : BaseEntity
    where TMapping : IEntityTypeConfiguration<TEntity>, new()
{
    private readonly IAppSettings appSettings;
    private readonly ILogger<BaseRepo<TEntity, TMapping>> logger;

    /// <summary>
    ///     Default constructor
    /// </summary>
    /// <param name="logger">Required logger for repo</param>
    /// <param name="appSettings">Required app settings</param>
    protected BaseRepo(ILogger<BaseRepo<TEntity, TMapping>> logger, IAppSettings appSettings)
    {
        this.logger = logger;
        this.appSettings = appSettings;
        Entities = base.Set<TEntity>();
    }

    /// <summary>
    ///     Entities for repo
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected DbSet<TEntity> Entities { get; }

    /// <inheritdoc />
    public async Task DeleteById(Guid id)
    {
        var entity = await base.Set<TEntity>().FirstAsync(a => a.Id == id);

        logger.LogDebug("Deleting {EntityType} with id {Id}", typeof(TEntity).Name, id);
        base.Set<TEntity>().Remove(entity);

        await SaveChanges();
    }

    /// <inheritdoc />
    public async Task<TEntity> FindById(Guid id)
    {
        logger.LogDebug("Finding {EntityType} with id {Id}", typeof(TEntity).Name, id);
        return await TryFindById(id) ??
               throw new EntityNotFoundException($"Could not find {typeof(TEntity).Name} with id {id}");
    }

    /// <inheritdoc />
    public async Task<IList<TEntity>> ListAll()
    {
        logger.LogDebug("Listing all entities for {EntityType}", typeof(TEntity).Name);
        return await base.Set<TEntity>().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<TEntity> Save(TEntity entity)
    {
        logger.LogInformation("Saving {EntityType} with id {Id}", typeof(TEntity).Name, entity.Id);
        if (Entities.Local.All(a => a != entity))
            await Entities.AddAsync(entity);

        await SaveChanges();

        return entity;
    }

    /// <inheritdoc />
    public async Task<TEntity?> TryFindById(Guid id)
    {
        logger.LogDebug("Finding {EntityType} with id {Id}", typeof(TEntity).Name, id);
        return await base.Set<TEntity>().FirstOrDefaultAsync(a => a.Id == id);
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        logger.LogDebug("Configuring context for {EntityType}", typeof(TEntity).Name);
        optionsBuilder.UseNpgsql(appSettings.ConnectionString);
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        logger.LogDebug("Configuring model for {EntityType}", typeof(TEntity).Name);
        modelBuilder.ApplyConfiguration(new TMapping());
        modelBuilder.Entity<TEntity>().ToTable(typeof(TEntity).Name, appSettings.Schema);
    }

    private new async Task SaveChanges()
    {
        logger.LogInformation("Saving changes for {EntityType}", typeof(TEntity).Name);
        var transactionTimer = Stopwatch.StartNew();
        var updatedEntityCount = await SaveChangesAsync();
        transactionTimer.Stop();
        logger.LogInformation(
            "Updated {Count} entities in {Seconds} seconds",
            updatedEntityCount,
            transactionTimer.Elapsed.TotalSeconds
        );
    }
}