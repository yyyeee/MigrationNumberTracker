using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MigrationNumberTracker.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            SerializeSettings(GlobalConfiguration.Configuration);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SerializeSettings(HttpConfiguration configuration)
        {
            var jsonSetting = new JsonSerializerSettings();
            jsonSetting.Converters.Add(new StringEnumConverter());
            configuration.Formatters.JsonFormatter.SerializerSettings = jsonSetting;
        }
    }
}
