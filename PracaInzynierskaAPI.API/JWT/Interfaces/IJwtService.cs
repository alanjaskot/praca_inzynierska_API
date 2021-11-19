using PracaInzynierskaAPI.API.JWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.JWT.Interfaces
{
    public interface IJwtService
    {
        Task<JwtAuthenticationTokenModel> CreateToken(Guid userId);
    }
}
