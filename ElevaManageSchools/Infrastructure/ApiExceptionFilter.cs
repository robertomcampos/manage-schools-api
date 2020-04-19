using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ElevaManageSchools.Infrastructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public object ExceptionToResult { get; private set; }

        public override void OnException(ExceptionContext context)
        {
            Console.Write(context.Result);
        }
    }
}
