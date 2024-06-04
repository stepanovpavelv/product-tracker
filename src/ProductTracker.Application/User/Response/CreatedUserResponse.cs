using ProductTracker.Application.Common;

namespace ProductTracker.Application.User.Response;

public sealed class CreatedUserResponse(long id) : IResponse
{
    public long Id { get; } = id;
}