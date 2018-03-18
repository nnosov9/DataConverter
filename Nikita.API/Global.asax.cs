using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nikita.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureJsonSerialization(GlobalConfiguration.Configuration);
        }
        /// <summary>
        /// Configure JSON Serialization.
        /// </summary>
        /// <param name="config"></param>
        private static void ConfigureJsonSerialization(HttpConfiguration config)
        {
            var jsonformatter = config.Formatters.OfType<JsonMediaTypeFormatter>().SingleOrDefault();

            if (jsonformatter != null)
            {
                jsonformatter.SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter(),
                    },
                };
                jsonformatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

                config.Formatters.Remove(jsonformatter);
                config.Formatters.Insert(0, jsonformatter);
            }
        }
    }
}
