﻿using System;
using System.Net;
using System.Threading.Tasks;
using Allergo.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Allergo.Web.Middleware
{
    public class BadRequestExceptionMiddleware
    {
        public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate next;

            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                var code = HttpStatusCode.InternalServerError;

                if (exception is BadRequestException) code = HttpStatusCode.BadRequest;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                return context.Response.WriteAsync(result);
            }
        }
    }
}