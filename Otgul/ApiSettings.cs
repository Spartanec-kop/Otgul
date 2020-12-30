using Newtonsoft.Json;

namespace Otgul.Api
{
    public class ApiSettings
    {
        /// <summary>
        /// Дефолтные настройки json серриализатора
        /// </summary>
        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
        {
        };
    }
}