using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace udemy
{
    public class Passo02
    {
        RequestDelegate _next;
        public Passo02(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Require
            var sw = new Stopwatch();
            sw.Start();

            await _next(context);

            //Response
            var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");

            if(context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
            {
                var body = context.Request.Body;
                
                using(var streamWrite = new StreamWriter(body))
                {
                    var textHtml = string.Format(
                        "<footer><div id='process'> Response Time {0} milliseconds.</div>", sw.ElapsedMilliseconds);
                    
                    streamWrite.Write(textHtml);
                    
                }
            }
        }
    }
}