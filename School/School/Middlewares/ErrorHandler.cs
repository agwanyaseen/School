using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;

namespace School.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception userexception)
            {
                await HandleExceptionAsync(httpContext, userexception);
            }

        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var exceptionResult = new ResultClass(null, exception.Message);
            JsonResult json = new JsonResult(exceptionResult);
            var route = httpContext.GetRouteData();
            var actionDescriptor = new ActionDescriptor();
            httpContext.Response.StatusCode = 400;
            ActionContext action = new ActionContext(httpContext,route,actionDescriptor);
            return json.ExecuteResultAsync(action);
        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }


    public class ResultClass
    {
        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }


        public ResultClass()
        {

        }

        public ResultClass(object result, object error)
        {
            
            Result = result;
            Error = error;
        }


    }
}
