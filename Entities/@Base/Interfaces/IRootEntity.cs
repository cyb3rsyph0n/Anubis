namespace Anubis.Entities.Base.Interfaces;

public interface IRootEntity
{
    Guid Id { get; }
    DateTime Created { get; }
    DateTime Modified { get; }
}