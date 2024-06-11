namespace ProductTracker.Domain.Shared;

/// <summary>
/// Интерфейс для настроек приложения.
/// </summary>
public interface IApplicationOption
{
    /// <summary>
    /// Путь к настройкам.
    /// </summary>
    static abstract string ConfigSectionPath { get; }
}