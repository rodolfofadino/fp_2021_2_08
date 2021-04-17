using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(TokenInfo model)
        {
            if (IsValid(model))
            {
                var token = GenerateToken(model);
                //salvou no banco

                return new ObjectResult(token);

            }
            return Unauthorized();
        }

        private string GenerateToken(TokenInfo model)
        {
            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256"));
            var credential = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credential);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, model.username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()));
            var payload = new JwtPayload(claims);

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValid(TokenInfo model)
        {
            return model.password == "123Mudei" && model.username == "appname";
        }
    }

    public class TokenInfo
    {
        public string password { get; set; }
        public string username { get; set; }
    }
}
