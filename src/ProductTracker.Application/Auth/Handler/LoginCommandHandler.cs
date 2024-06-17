﻿using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Options;
using ProductTracker.Application.Auth.Command;
using ProductTracker.Application.Auth.Response;
using ProductTracker.Domain.AppSetting;
using ProductTracker.Domain.Repository;
using ProductTracker.Utils;

namespace ProductTracker.Application.Auth.Handler;

/// <summary>
/// Аутентификация пользователя в системе.
/// </summary>
public sealed class LoginCommandHandler(
    IOptions<JwtOption> option,
    IUserRepository userRepository,
    IJwtManagerRepository jwtManagerRepository,
    IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<LoginCommand, Result<AuthTokenResponse>>
{
    private readonly JwtOption _setting = option.Value;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtManagerRepository _jwtManagerRepository = jwtManagerRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<AuthTokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request, nameof(request));

        var user = await _userRepository.GetByLogin(request.Login, cancellationToken);
        if (user == null)
        {
            return Result<AuthTokenResponse>.Error($"Пользователя с таким логином не зарегистрирован: {request.Login}");
        }

        var hashedPassword = HashingUtils.GetPasswordHash(_setting.Key, request.Password);
        if (!string.Equals(user.Password, hashedPassword)) {
            return Result<AuthTokenResponse>.Error($"Введен некорректный пароль для пользователя: {request.Login}");
        }

        var accessToken = _jwtManagerRepository.GenerateAccessToken(user.Login);
        var refreshToken = _jwtManagerRepository.GenerateRefreshToken();

        await _refreshTokenRepository.SaveUserIdToken(user.Id, refreshToken, cancellationToken);

        var result = new AuthTokenResponse
        { 
            AccessToken = accessToken, 
            RefreshToken = refreshToken 
        };

        return Result<AuthTokenResponse>.Success(result);
    }
}