#pragma warning disable CS0649

using Anubis.Entities.Base.Interfaces;

namespace Anubis.Entities.Base.Types;

/// <summary>
///     Base entity
/// </summary>
public class BaseEntity : IRootEntity
{
    private readonly DateTime created;
    private readonly Guid id;
    private readonly DateTime modified;

    /// <summary>
    ///     Entity id
    /// </summary>
    public Guid Id => id;

    /// <summary>
    ///     Entity created date time
    /// </summary>
    public DateTime Created => created;

    /// <summary>
    ///     Entity modified date time
    /// </summary>
    public DateTime Modified => modified;
}