using Anubis.Entities.Base.Interfaces;

namespace Anubis.Entities.Base.Types;

/// <summary>
///     Base for all response dtos
/// </summary>
public class BaseDto : IRootEntity
{
    /// <summary>
    ///     Entity id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Entity created date and time
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    ///     Entity modified date and time
    /// </summary>
    public DateTime Modified { get; set; }
}