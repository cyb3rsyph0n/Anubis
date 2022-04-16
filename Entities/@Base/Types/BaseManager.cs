using Anubis.Entities.Base.Interfaces;

namespace Anubis.Entities.Base.Types;

/// <summary>
///     Base manager for entities
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
public abstract class BaseManager<TEntity> : IBaseManager<TEntity> where TEntity : BaseEntity
{
    private readonly ILogger<BaseManager<TEntity>> logger;

    /// <summary>
    ///     Default ctor
    /// </summary>
    /// <param name="logger">Required logger for logging</param>
    /// <param name="repo">Required repo</param>
    protected BaseManager(ILogger<BaseManager<TEntity>> logger, IBaseRepo<TEntity> repo)
    {
        Repo = repo;
        this.logger = logger;
    }

    /// <summary>
    ///     Repo for this manager
    /// </summary>
    // ReSharper disable once MemberCanBePrivate.Global
    protected IBaseRepo<TEntity> Repo { get; }

    /// <inheritdoc />
    public async Task DeleteById(Guid id)
    {
        await Repo.DeleteById(id);
    }

    /// <inheritdoc />
    public async Task<TEntity> FindById(Guid id)
    {
        return await Repo.FindById(id);
    }

    /// <inheritdoc />
    public async Task<IList<TEntity>> ListAll()
    {
        return await Repo.ListAll();
    }
}