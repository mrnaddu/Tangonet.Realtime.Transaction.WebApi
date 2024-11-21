namespace Tangonet.Realtime.Transaction.WebApi.Models;

public class ErrorResponse(int status, string errorCode, string message, string traceId)
{
    public int Status { get; set; } = status;
    public string ErrorCode { get; set; } = errorCode;
    public string Message { get; set; } = message;
    public string TraceId { get; set; } = traceId;

    public static ErrorResponse BadRequest(string message, string traceId)
    {
        return new ErrorResponse(400, "TNTTS4000", message, traceId);
    }
    public static ErrorResponse InternalServerError(string message, string traceId)
    {
        return new ErrorResponse(500, "TNTTS5000", message, traceId);
    }
    public static ErrorResponse NotFound(string message, string traceId)
    {
        return new ErrorResponse(404, "TNTTS4004", message, traceId);
    }
    public static ErrorResponse Forbidden(string message, string traceId)
    {
        return new ErrorResponse(403, "TNTTS4003", message, traceId);
    }
    public static ErrorResponse Unauthorized(string message, string traceId)
    {
        return new ErrorResponse(401, "TNTTS4001", message, traceId);
    }
}
