using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFC.Blog.Entities.Concrete;

namespace MFC.Blog.Business.Tools.JWTTools
{
    public interface IJwtService
    {
        JwtToken GenerateJwt(AppUser appUser);
    }
}
