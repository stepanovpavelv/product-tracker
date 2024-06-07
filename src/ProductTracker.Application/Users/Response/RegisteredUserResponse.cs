using ProductTracker.Application.Common;

namespace ProductTracker.Application.Users.Response;

public sealed class RegisteredUserResponse(long id) : IResponse
{
    public long Id { get; } = id;
}