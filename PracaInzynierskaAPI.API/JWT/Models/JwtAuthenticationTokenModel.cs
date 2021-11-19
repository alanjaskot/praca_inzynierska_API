using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.JWT.Models
{
    public class JwtAuthenticationTokenModel
    {
        public string Token { get; }

        public string Type { get; }

        public JwtAuthenticationTokenModel(string type, string token)
        {
            Token = token;
            Type = type;
        }
    }
}
