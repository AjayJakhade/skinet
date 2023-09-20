using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Error;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public IHostEnvironment _Env { get; }
        public ExceptionMiddleware( RequestDelegate next,ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            _Env = env;
            _logger = logger;
            _next = next;

        }
        public async Task InvokeAsync(HttpContext context){
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
                var options=new JsonSerializerOptions{PropertyNamingPolicy =JsonNamingPolicy.CamelCase};
                 var response=_Env.IsDevelopment()? new APIException((int) HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString()):new APIException((int)HttpStatusCode.InternalServerError);
                var json=JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}