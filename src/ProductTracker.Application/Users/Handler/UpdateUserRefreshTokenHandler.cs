using Ardalis.Result;
using MediatR;
using ProductTracker.Application.Users.Command;
using ProductTracker.Application.Users.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductTracker.Application.Users.Handler;

public sealed class UpdateUserRefreshTokenHandler : IRequestHandler<UpdateUserRefreshTokenCommand, Result<AuthTokenUserResponse>>
{
    public Task<Result<AuthTokenUserResponse>> Handle(UpdateUserRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}