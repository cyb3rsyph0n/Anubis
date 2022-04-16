using Anubis.Entities.Base.Types;

namespace Anubis.Entities.Base.Interfaces;

public interface IBaseManager<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Delete entity by its id
    /// </summary>
    /// <param name="id">Required id of entity to delete</param>
    /// <returns></returns>
    Task DeleteById(Guid id);

    /// <summary>
    ///     Find an entity by its id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    Task<TEntity> FindById(Guid id);

    /// <summary>
    ///     List all entities of the given type
    /// </summary>
    /// <returns></returns>
    Task<IList<TEntity>> ListAll();
}