using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace DinnerInvite.Api.Middleware
{
    public class ErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleWare(RequestDelegate next)
        {
            _next=next;
        }

        public async Task Invoke(HttpContext context){
            try
            {
                await _next(context);
            }
            catch(Exception ex){
                await HandleExceptionAsync(context,ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context,Exception ex){
            var code=HttpStatusCode.InternalServerError;//500
            var result=JsonSerializer.Serialize(new {error=$"An Error Occured While Processing Request.Message:{ex.Message}"});
            context.Response.ContentType="application/json";
            context.Response.StatusCode=(int)code;
            return context.Response.WriteAsync(result.Replace(".","\n"));
        }
    }
}