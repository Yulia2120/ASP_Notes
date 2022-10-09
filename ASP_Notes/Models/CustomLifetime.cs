using Microsoft.IdentityModel.Tokens;

namespace ASP_Notes.Models
{
    public class CustomLifetime
    {
        //метод, на который будет указывать делегат LifetimeValidator. Сравниваем дату истечения срока действия токена с текущей датой
        static public bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires,
            SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
    }
}
