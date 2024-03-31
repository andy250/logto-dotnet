using RestSharp.Authenticators;

namespace andy250.LogToDotnet.Authn
{
    /// <summary>
    /// https://docs.logto.io/sdk/m2m/
    /// </summary>
    internal class LogToAuthenticator : AuthenticatorBase
    {
        private readonly string baseUrl;
        private readonly string username;
        private readonly string password;
        private readonly string resource;
        private readonly string? scope;

        private DateTime? accessTokenExpires;

        internal LogToAuthenticator(LogToConfig config) : base(string.Empty)
        {
            baseUrl = config.BaseUrl;
            username = config.AppId;
            password = config.AppSecret;
            resource = config.ManagementApi;
            scope = config.ManagementApiScope;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            if (TokenRequiresRevalidation())
            {
                await RefreshToken();
            }

            return new HeaderParameter(KnownHeaders.Authorization, "Bearer " + Token);
        }

        private bool TokenRequiresRevalidation()
        {
            return
                Token is null ||
                accessTokenExpires is null ||
                DateTime.UtcNow > accessTokenExpires.Value.AddMinutes(-1);
        }

        private async Task RefreshToken()
        {
            var opts = new RestClientOptions(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };
            
            using var client = new RestClient(opts);

            var request = new RestRequest("oidc/token", Method.Post);

            request
                .AddParameter("grant_type", "client_credentials")
                .AddParameter("resource", resource);
            
            if (scope is not null)
            {
                request.AddParameter("scope", scope);
            }

            var tokenResponse = await client.PostAsync<TokenResponse>(request);

            this.Token = tokenResponse!.AccessToken;
            this.accessTokenExpires = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);
        }
    }
}
