using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Token
{
    public struct AuthenticationOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "MyUsers"; 
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 480; 
        // срок токена - 8 часов = рабочий день

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
