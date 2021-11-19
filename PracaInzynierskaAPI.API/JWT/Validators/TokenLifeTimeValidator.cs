using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.JWT.Validators
{
    public class TokenLifeTimeValidator
    {
        public static bool Validate(
               DateTime? notBefore,
               DateTime? expires,
               SecurityToken securityToken,
               TokenValidationParameters validationParameters
           )
        {
            if (notBefore is null)
            {
                throw new ArgumentNullException(nameof(notBefore));
            }

            if (expires is null)
            {
                throw new ArgumentNullException(nameof(expires));
            }

            if (securityToken is null)
            {
                throw new ArgumentNullException(nameof(securityToken));
            }

            if (validationParameters is null)
            {
                throw new ArgumentNullException(nameof(validationParameters));
            }

            return (expires != null && expires > DateTime.UtcNow);
        }
    }
}
