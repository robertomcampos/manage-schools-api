namespace ElevaManageSchools.Infrastructure
{
    public enum ErrorCode
    {
        InvalidInput,
        InvalidRequest,
        InvalidObjectState,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalError = 500,
    }

    public class ErrorInfo
    {
        public ErrorInfo(ErrorCode code) : this(code, null) { }
        public ErrorInfo(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public ErrorCode Code { get; }
        public string Message { get; }
    }
}
