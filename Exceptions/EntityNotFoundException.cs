namespace Anubis.Exceptions;

/// <summary>
///     Used when an entity is not found
/// </summary>
public class EntityNotFoundException : BaseException
{
    /// <inheritdoc />
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}