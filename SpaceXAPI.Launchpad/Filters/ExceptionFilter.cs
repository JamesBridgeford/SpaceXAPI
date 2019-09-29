using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpaceXAPI.Interfaces;
using System.Net;

namespace SpaceXAPI.Launchpad.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogEvents _logger;

        public ExceptionFilter(ILogEvents logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogException("ExceptionFilter", "Unhandle exception from application", context.Exception);
            context.Result = new StatusCodeResult((int)HttpStatusCode.InternalServerError);
        }
    }
}
