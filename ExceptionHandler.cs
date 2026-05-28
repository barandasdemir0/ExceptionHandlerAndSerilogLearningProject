using Microsoft.AspNetCore.Diagnostics;

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
            exception.Message
        });//exceptionları mesaj yaptık  ve her zaman json gönderki front doğru işleşin
        return true;//metodun işi bitti
    }
}
