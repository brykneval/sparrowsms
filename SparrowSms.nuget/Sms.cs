using System;
using System.Net;
using System.Web;

namespace SparrowSms.nuget
{
    public class Sms : ISparrowSms
    {
        private readonly string from;
        private readonly string token;
        private readonly Action<Exception> onError;
        private readonly Action<string> onSuccess;

        public Sms(string from, string token, Action<string> onSuccess = null, Action<Exception> onError = null)
        {
            this.from = from;
            this.token = token;
            this.onError = onError;
            this.onSuccess = onSuccess;
        }

        public void SendSms(string to, string message)
        {
            using (var client = new WebClient())
            {
                var uriBuilder = new UriBuilder("http://api.sparrowsms.com/v2/sms");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["from"] = from;
                parameters["to"] = to;
                parameters["text"] = message;
                parameters["token"] = token;
                uriBuilder.Query = parameters.ToString();
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                client.DownloadStringAsync(uriBuilder.Uri);
            }
        }

        private void client_DownloadStringCompleted(object sender,
            DownloadStringCompletedEventArgs args)
        {
            if (args.Error != null)
            {
                if (onError != null)
                    onError(args.Error);
            }
            else
            {
                if (onSuccess != null)
                    onSuccess(args.Result);
            }
        }
    }
}