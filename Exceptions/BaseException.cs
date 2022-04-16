namespace Anubis.Exceptions;

/// <summary>
///     Base exception used for intercepting in middleware
/// </summary>
public class BaseException : Exception
{
    /// <inheritdoc />
    protected BaseException(string message)
        : base(message)
    {
    }
}