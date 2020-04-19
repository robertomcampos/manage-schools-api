using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        InternalError = 500, //Errors from here will be returned as HttpStatus on Controller filter: 500
    }

    public class ErrorInfo
    {
        public ErrorInfo(ErrorCode code) : this(code, null) { }
        public ErrorInfo(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public ErrorCode? Code { get; }

        public string Message { get; }
    }

    public class NotMappedErrorInfo : ErrorInfo
    {
        public NotMappedErrorInfo(Exception ex) : base(ErrorCode.InternalError, $"Unexpected Error details: {ex.Message}") { }
    }
}
