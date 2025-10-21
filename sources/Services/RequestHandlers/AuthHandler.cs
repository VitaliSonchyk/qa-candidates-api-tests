using Serilog;
using Services.QACandidatesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Services.RequestHandlers
{
    public class AuthHandler : DelegatingHandler
    {
        private ILoginService _loginService;
        public AuthHandler(ILoginService loginService) => _loginService = loginService;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = (await _loginService.LoginAsync()).AccessToken;

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            Log.Information("Injected token into request {Url}", request.RequestUri);

            return await base.SendAsync(request, cancellationToken);
        }

    }
}
