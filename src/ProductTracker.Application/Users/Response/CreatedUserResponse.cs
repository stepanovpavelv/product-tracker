using ProductTracker.Application.Common;

namespace ProductTracker.Application.Users.Response;

public sealed class CreatedUserResponse(long id) : IResponse
{
    public long Id { get; } = id;
}