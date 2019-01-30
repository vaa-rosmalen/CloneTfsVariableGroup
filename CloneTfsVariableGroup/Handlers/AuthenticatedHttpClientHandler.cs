using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CloneTfsVariableGroup.Handlers
{
    public class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly string _token;

        public AuthenticatedHttpClientHandler(string token) =>
            _token = token;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                var byteArray = Encoding.ASCII.GetBytes($"username:{_token}");
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, Convert.ToBase64String(byteArray));
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
