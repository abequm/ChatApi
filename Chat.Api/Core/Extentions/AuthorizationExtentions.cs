using System.Security.Claims;

namespace Chat.Api.Core.Extentions
{
    public static class AuthorizationExtentions
    {
        public static int Id(this ClaimsPrincipal claims) => Int32.Parse(claims.Claims.First(e => e.Type == "Id").Value);
    }
}
