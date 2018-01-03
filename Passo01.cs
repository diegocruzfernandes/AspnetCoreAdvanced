using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace udemy
{
    public class Passo01
    {
        RequestDelegate _next;

        public Passo01(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Request
            var query = context.Request.Query["branch"];

            await _next(context);

            await context.Response.WriteAsync($"Branch used = {query} ");
        }
    }
}