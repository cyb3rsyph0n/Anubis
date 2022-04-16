using Anubis.Entities.Base.Types;

namespace Anubis.Entities.Base.Interfaces;

/// <summary>
///     Transformer interface
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TDto">Required dto return type</typeparam>
public interface IBaseTransformer<in TEntity, TDto> where TEntity : BaseEntity where TDto : BaseDto
{
    /// <summary>
    ///     Convert an entity to a dto
    /// </summary>
    /// <param name="entity">Required entity to convert</param>
    /// <returns></returns>
    TDto ToDto(TEntity entity);

    /// <summary>
    ///     Convert a list of entities to a list of dtos
    /// </summary>
    /// <param name="entities">Required list of entities</param>
    /// <returns></returns>
    IList<TDto> ToDtoList(IEnumerable<TEntity> entities);
}