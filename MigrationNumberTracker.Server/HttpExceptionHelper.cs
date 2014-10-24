using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MigrationNumberTracker.Server
{
    public static class HttpExceptionHelper
    {
        public static HttpResponseException ServerError(string message)
        {
            return CreateException(HttpStatusCode.InternalServerError, message);
        }

        private static HttpResponseException CreateException(HttpStatusCode status, string message, string parameter = null, HttpRequestMessage requestMessage = null)
        {
            var httpError = new HttpError(message);
            if (!string.IsNullOrEmpty(parameter))
            {
                httpError.Add("Parameter", parameter);
            }

            var msg = new HttpResponseMessage(status)
            {
                Content = new ObjectContent<HttpError>(httpError, GlobalConfiguration.Configuration.Formatters.JsonFormatter),
                RequestMessage = requestMessage
            };

            return new HttpResponseException(msg);
        }
    }
}