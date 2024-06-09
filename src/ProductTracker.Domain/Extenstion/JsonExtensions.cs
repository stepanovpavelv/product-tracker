using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace ProductTracker.Domain.Extenstion;

public static class JsonExtensions
{
    private static readonly Lazy<JsonSerializerOptions> LazyOptions =
        new(() => new JsonSerializerOptions().Configure(), isThreadSafe: true);

    /// <summary>
    /// Конвертирует (десериализует) json-строку в объект типа T.
    /// </summary>
    /// <typeparam name="T">Тип объекта для десериализации.</typeparam>
    /// <param name="value">JSON-строка для десериализации.</param>
    /// <returns>Десериализованный объект типа T.</returns>
    public static T? FromJson<T>(this string value) =>
        value != null ? JsonSerializer.Deserialize<T>(value, LazyOptions.Value) : default;

    /// <summary>
    /// Конвертирует (сериализует) объект типа T в строку.
    /// </summary>
    /// <typeparam name="T">Тип объекта для десериализации.</typeparam>
    /// <param name="value">Объект для конвертации.</param>
    /// <returns>JSON-строка представления объекта типа T.</returns>
    public static string? ToJson<T>(this T value) =>
        !value.IsDefault() ? JsonSerializer.Serialize(value, LazyOptions.Value) : default;

    /// <summary>
    /// Настроить объект JsonSerializerOptions.
    /// </summary>
    /// <param name="jsonSettings">JsonSerializerOptions-объект для настройки.</param>
    /// <returns>Сконфигурированный JsonSerializerOptions-объект.</returns>
    public static JsonSerializerOptions Configure(this JsonSerializerOptions jsonSettings)
    {
        jsonSettings.WriteIndented = false;
        jsonSettings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        jsonSettings.ReadCommentHandling = JsonCommentHandling.Skip;
        jsonSettings.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        jsonSettings.TypeInfoResolver = new PrivateConstructorContractResolver();
        jsonSettings.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        return jsonSettings;
    }
}

internal sealed class PrivateConstructorContractResolver : DefaultJsonTypeInfoResolver
{
    /// <summary>
    /// Получить информацию в виде JsonTypeInfo для переданного типа с поддержкой создания объекта с помощью приватного конструктора.
    /// </summary>
    /// <param name="type">Тип для получения сведений.</param>
    /// <param name="options">Объект-<see cref="JsonSerializerOptions"/> для сериализации.</param>
    /// <returns>Информация в виде JsonTypeInfo о переданном типе.</returns>
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var jsonTypeInfo = base.GetTypeInfo(type, options);

        // Проверяем, если ли у класса объекта public-конструктор, и CreateObject не заполнено
        if (jsonTypeInfo.Kind == JsonTypeInfoKind.Object
            && jsonTypeInfo.CreateObject is null
            && jsonTypeInfo.Type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length == 0)
        {
            // Генерим CreateObject с помощью лямбды, которая юзает приватный конструктор
#pragma warning disable CS8603 // Possible null reference return.
            jsonTypeInfo.CreateObject = () => Activator.CreateInstance(jsonTypeInfo.Type, true);
#pragma warning restore CS8603 // Possible null reference return.
        }

        return jsonTypeInfo;
    }
}
