namespace ProductTracker.Domain.Extenstion;

public static class TExtensions
{
    /// <summary>
    /// Проверить, является ли объект дефолтным значением (для ссылочных типов null).
    /// </summary>
    /// <typeparam name="T">Тип объекта.</typeparam>
    /// <param name="value">Ссылка на объект / значение объекта.</param>
    /// <returns>Результат сравнения.</returns>
    public static bool IsDefault<T>(this T value) =>
        Equals(value, default(T));
}
