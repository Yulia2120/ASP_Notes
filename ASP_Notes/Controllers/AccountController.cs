using ASP_Notes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP_Notes.Controllers //Тестовый файл
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly JWTSettings _options;
        //конструктор контроллера получает параметры токена, хранящиеся в файле appsettings.json
        public AccountController(IOptions<JWTSettings> optAccess)
        {
            _options = optAccess.Value;
        }
        //метод для выдачи токена
        [HttpGet("GetToken")]
        public string GetToken()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Yuliya"));
            claims.Add(new Claim("level", "123"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
         //заполняем токен, указывая издателя, потребителя, ключ, информацию о пользователе, дату выдачи и срок действия токена (у нас 1мин.)
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));


             return new JwtSecurityTokenHandler().WriteToken(jwt);

            //https://jwt.io/ проверить правильность кодировки
        }
    }
}
