using Newtonsoft.Json;

namespace StudentData.Api
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