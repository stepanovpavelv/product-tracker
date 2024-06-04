using System.Text.Json.Serialization;

namespace ProductTracker.Web.Model;

[method: JsonConstructor]
public sealed class ApiErrorResponse(string message)
{
    private readonly string _message = message;

    public string Message { get { return _message; } }

    public override string ToString() => _message;
}