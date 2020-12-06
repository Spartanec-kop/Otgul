using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface ITokenService
    {
        string Generate(string userLogin);

        ClaimsPrincipal DecodeToken(string jwt);
    }
}
