using Microsoft.AspNetCore.Http;

namespace ExampleApp.Service.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static int? UserId => GetUserId();
    public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

    private static int? GetUserId()
    {
        int id;
        bool canParse = int.TryParse(HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value, out id);
        return canParse ? id : null;
    }
}