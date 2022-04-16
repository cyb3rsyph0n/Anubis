using Anubis.Entities.Base.Interfaces;

namespace Anubis.Entities.Base.Types;

/// <summary>
///     Base transformer
/// </summary>
/// <typeparam name="TEntity">Required entity type</typeparam>
/// <typeparam name="TDto">Required dto type</typeparam>
public abstract class BaseTransformer<TEntity, TDto> : IBaseTransformer<TEntity, TDto>
    where TEntity : BaseEntity where TDto : BaseDto
{
    /// <inheritdoc />
    public abstract TDto ToDto(TEntity entity);

    /// <inheritdoc />
    public virtual IList<TDto> ToDtoList(IEnumerable<TEntity> entities)
    {
        return entities.Select(ToDto).ToList();
    }
}