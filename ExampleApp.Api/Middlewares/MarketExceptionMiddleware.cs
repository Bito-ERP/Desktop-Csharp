using ExampleApp.Service.Exceptions;

namespace ExampleApp.Api.Middlewares;

public class MarketExceptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<MarketExceptionMiddleware> logger;
    public MarketExceptionMiddleware(RequestDelegate next, ILogger<MarketExceptionMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (MarketException ex)
        {
            await HandleExceptionAsync(context, ex.Code, ex.Message);
        }
        catch (Exception ex)
        {
            // log
            logger.LogError(ex.ToString());
            Console.WriteLine(ex.ToString());
            await HandleExceptionAsync(context, 500, ex.Message);
        }
    }
    public async Task HandleExceptionAsync(HttpContext context, int code, string message)
    {
        context.Response.StatusCode = code;
        await context.Response.WriteAsJsonAsync(new
        {
            Code = code,
            Message = message
        });
    }
}