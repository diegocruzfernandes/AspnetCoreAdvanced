using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace udemy
{
    public class MyMiddleware
    {
        RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Request
            var start = DateTime.Now;
            
            await _next(context);

            //Response
            var finish = DateTime.Now;

            var diff = finish.Subtract(start);

            await context.Response.WriteAsync($"The time was {diff.Milliseconds}");
        }
    }
}