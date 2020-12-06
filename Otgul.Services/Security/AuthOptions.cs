using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Otgul.Services.Security
{
    public class AuthOptions
    {
        /// <summary>
        /// Издатель токена
        /// </summary>
        internal const string Issuer = "StudentData.Auth.Server";
        
        /// <summary>
        /// Потребитель токена
        /// </summary>
        internal const string Audience = "StudentData.Client";
        
        /// <summary>
        /// Ключ шифрования
        /// </summary>
        private const string Key = "ViFUbO80zToIFr4eOWYb";
        
        /// <summary>
        /// Срок жизни, в днях
        /// </summary>
        internal const int Lifetime = 2;

        /// <summary>
        /// Ключ шифрования
        /// </summary>
        internal static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
        
        /// <summary>
        ///  Параметры валидации токенов
        /// </summary>
        public static TokenValidationParameters GetTokenParameters()
        {
            return new TokenValidationParameters
            {
                // укзывает, будет ли валидироваться издатель при валидации токена
                ValidateIssuer = true,
                // строка, представляющая издателя
                ValidIssuer = AuthOptions.Issuer,
 
                // будет ли валидироваться потребитель токена
                ValidateAudience = true,
                // установка потребителя токена
                ValidAudience = AuthOptions.Audience,
                // будет ли валидироваться время существования
                ValidateLifetime = true,
 
                // установка ключа безопасности
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                // валидация ключа безопасности
                ValidateIssuerSigningKey = true,
            };
        } 
    }
}