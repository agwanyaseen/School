﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
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
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionDetails = Result.Failure(exception.Message);
            var error = new ResultClass<string>(null, exception.Message);
            var jsonResult = JsonConvert.SerializeObject(error, Formatting.Indented);
            httpContext.Response.StatusCode = (int)statusCode;
            return httpContext.Response.WriteAsync(jsonResult);
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


    public class ResultClass<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        public ResultClass(T result, string error)
        {
            Result = result;
            Error = error;
        }

    }
}
