namespace Tangonet.Realtime.Transaction.WebApi.Models;

public class ErrorResponse
{
    public int Status { get; set; }
    public string ErrorCode { get; set; }
    public string Message { get; set; }
    public string TraceId { get; set; }
    public ErrorResponse(int status, string errorCode, string message, string traceId)
    {
        Status = status;
        ErrorCode = errorCode;
        Message = message;
        TraceId = traceId;
    }
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
        return new ErrorResponse(200, "TNTTS4004", message, traceId);
    }
    public static ErrorResponse Forbidden(string message, string traceId)
    {
        return new ErrorResponse(403, "TNTTS4003", message, traceId);
    }
}
