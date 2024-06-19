using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Auth.Response;

namespace ProductTracker.Application.Auth.Command;

/// <summary>
/// Команда на получение refresh-токена пользователя.
/// </summary>
public sealed class GetRefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>
{
}