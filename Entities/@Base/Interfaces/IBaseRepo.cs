using Anubis.Entities.Base.Types;

namespace Anubis.Entities.Base.Interfaces;

/// <summary>
///     Repo interface
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
public interface IBaseRepo<TEntity> : IBaseProvider<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Delete an entity by its id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    Task DeleteById(Guid id);

    /// <summary>
    ///     Save an entity
    /// </summary>
    /// <param name="entity">Required entity to save</param>
    /// <returns></returns>
    Task<TEntity> Save(TEntity entity);
}