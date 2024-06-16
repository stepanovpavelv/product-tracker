using ProductTracker.Application.Common;

namespace ProductTracker.Application.Users.Response;

/// <summary>
/// Ответ системы на регистрацию пользователя.
/// </summary>
public sealed class RegisteredUserResponse(long id) : IResponse
{
    /// <summary>
    /// Уникальный идентификатор пользователя.
    /// </summary>
    public long Id { get; } = id;
}