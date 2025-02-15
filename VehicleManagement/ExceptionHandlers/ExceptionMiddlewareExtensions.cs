﻿using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using VehicleManagement.Models;

namespace VehicleManagement.ExceptionHandlers
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app,ILogger logger) 
        {
            app.UseExceptionHandler(appError =>
            {
               appError.Run(async context=>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"Something Went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorMessages()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal server Error"
                        }.ToString());
                    }
                });
            });
            
        }

    }
}
