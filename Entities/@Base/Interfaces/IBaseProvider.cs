using Anubis.Entities.Base.Types;

namespace Anubis.Entities.Base.Interfaces;

public interface IBaseProvider<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    ///     Find an entity by its id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    Task<TEntity> FindById(Guid id);

    /// <summary>
    ///     List all entities of TEntity type
    /// </summary>
    /// <returns></returns>
    Task<IList<TEntity>> ListAll();

    /// <summary>
    ///     Try to find an entity by its id
    /// </summary>
    /// <param name="id">Required id to search for</param>
    /// <returns></returns>
    Task<TEntity?> TryFindById(Guid id);
}