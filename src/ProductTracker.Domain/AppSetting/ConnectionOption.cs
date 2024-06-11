using ProductTracker.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Domain.AppSetting;

public sealed class ConnectionOption : IApplicationOption
{
    static string IApplicationOption.ConfigSectionPath => "ConnectionStrings";

    [Required]
    public string NpgsqlConnectionString { get; private init; } = null!;
}