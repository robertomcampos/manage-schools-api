using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace ElevaManageSchools.Infrastructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public object ExceptionToResult { get; private set; }

        public override void OnException(ExceptionContext context)
        {
            var logger = GetLogger(context);

            LogException(context.Exception, logger);

            if (context.Result != null)
                return;

            switch (context.Exception)
            {
                case DatabaseException _:
                    context.Result = new UnprocessableEntityResult();
                    return;
                case ArgumentNullException ae:
                    context.Result = new ObjectResult(new ErrorInfo(ErrorCode.NotFound, $"Attribute: {ae.ParamName} is mandatory"));
                    break;
                default:
                    context.Result = new ObjectResult(new ErrorInfo(ErrorCode.InternalError, $"Unexpected Error details: {context.Exception.Message}"));
                    break;
            }
        }

        private void LogException(Exception ex, ILogger logger) => logger?.Log(LogLevel.Error, ex.Message);
        private ILogger GetLogger(ExceptionContext context)
        {
            var loggerFactory = (ILoggerFactory)context.HttpContext.RequestServices.GetService(typeof(ILoggerFactory));
            Type controllerType = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerTypeInfo.UnderlyingSystemType;
            return loggerFactory.CreateLogger(controllerType);
        }
    }
}
