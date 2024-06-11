using ProductTracker.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace ProductTracker.Domain.AppSetting;

public sealed class JwtOption : IApplicationOption
{
    static string IApplicationOption.ConfigSectionPath => "JWT";

    [Required]
    public string Key { get; private init; } = null!;

    [Required]
    public string Issuer { get; private init; } = null!;

    [Required]
    public string Audience { get; private init; } = null!;
}