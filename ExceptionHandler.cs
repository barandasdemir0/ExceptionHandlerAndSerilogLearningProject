using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace ExceptionHandlerAndSerilog.WebAPI;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync
        (
        HttpContext httpContext, //api isteğinin bağlı bulunduğu context
        Exception exception,  //exception örneği try catche bunla yakalar
        CancellationToken cancellationToken
        )
    {
        httpContext.Response.StatusCode = 400;  //code olarak belirledik
        await httpContext.Response.WriteAsJsonAsync(new
        {
            Message = exception.Message
        });//exceptionları mesaj yaptık  ve her zaman json gönderki front doğru işleşin


        //validasyon hataları için
        if (exception.GetType() == typeof(ValidationException))
        {
            httpContext.Response.StatusCode = 403;
        }





        return true;//metodun işi bitti
    }
}
