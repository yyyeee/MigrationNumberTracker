using System;
using System.Net;
using MigrationNumberTracker.Common;
using RestSharp;

namespace MigrationNumberTracker.Client
{
    public class MigrationNumberTrackerClient
    {
        public string Url { get; set; }

        public long ReserveMigrationNumber(MigrationType type)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("migrations/{type}/reserve", Method.POST) {RequestFormat = DataFormat.Json};
            request.AddParameter("type", type.ToString(), ParameterType.UrlSegment);
            var response = client.Execute(request);
            ThrowIfFailed(response);
            return GetLongOrThrow(response);
        }

        private static long GetLongOrThrow(IRestResponse response)
        {
            long result;
            var success = long.TryParse(response.Content, out result);
            if (!success)
            {
                throw new Exception(response.Content);
            }
            return result;
        }

        public void UpdateMigrationNumber(MigrationType type, long number)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("migrations/{type}/{number}", Method.POST);
            request.AddParameter("type", type, ParameterType.UrlSegment);
            request.AddParameter("number", number, ParameterType.UrlSegment);
            var response = client.Execute(request);
            ThrowIfFailed(response);
        }

        public long ReadMigrationNumber(MigrationType type)
        {
            var client = new RestClient(Url);
            var request = new RestRequest("migrations/{type}", Method.GET);
            request.AddParameter("type", type, ParameterType.UrlSegment);
            var response = client.Execute(request);
            ThrowIfFailed(response);
            return GetLongOrThrow(response);
        }

        private void ThrowIfFailed(IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.ErrorException != null)
                {
                    throw response.ErrorException;
                }

                if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                {
                    throw new Exception(response.ErrorMessage);
                }

                throw new Exception(response.Content);
            }
        }
    }
}
