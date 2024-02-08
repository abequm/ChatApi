using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Chat.Api.Constants
{
    public static class AuthOptions
    {
        public const string ISSUER = "ChatServer";
        public const string AUDIENCE = "ChatClient";
        const string KEY = "secret_key123secret_key123";  
        public const int LIFETIME = 24;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
