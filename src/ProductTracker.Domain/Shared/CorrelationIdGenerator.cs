namespace ProductTracker.Domain.Shared;

/// <summary>
/// Является генератором для значения Correlation-ID.
/// </summary>
public sealed class CorrelationIdGenerator
{
    private string correlationId = Guid.NewGuid().ToString("D");

    /// <summary>
    /// Сгенерировать значение Correlation-ID.
    /// </summary>
    /// <returns>Созданное значение для Correlation-ID.</returns>
    public string Get() => correlationId;

    /// <summary>
    /// Устанавливает значение Correlation-ID
    /// </summary>
    /// <param name="correlationId">Значение Correlation-ID для сохранения.</param>
    public void Set(string correlationId) => this.correlationId = correlationId;
}