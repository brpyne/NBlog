using ServiceStack.ServiceInterface.Auth;

namespace Fullback.WebHost.App_Start
{
    public class CustomUserSession : AuthUserSession
    {
        public string CustomProperty { get; set; }
    }
}