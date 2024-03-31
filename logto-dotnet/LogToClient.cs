using andy250.LogToDotnet.Authn;

namespace andy250.LogToDotnet
{
    /// <remarks>
    /// Every instance of <see cref="LogToClient" /> uses one instance of <see cref="LogToAuthenticator" />. Authenticator class 
    /// will cache accessToken for some time (defined by LogTo token endpoint response --> <see cref="TokenResponse.ExpiresIn"/>.
    /// If you need to access multiple different tenants of LogTo - each needs a separate instance of <see cref="LogToClient" />.
    /// </remarks>
    public class LogToClient : ILogToClient
    {
        private RestClient client;

        public LogToClient(LogToConfig config)
        {
            var options = new RestClientOptions(config.BaseUrl.TrimEnd('/') + "/api")
            {
                Authenticator = new LogToAuthenticator(config)
            };
            this.client = new RestClient(options);
        }

        public async Task<List<dynamic>> GetApplications(CancellationToken cancel = default)
        {
            var request = new RestRequest($"applications");
            return await this.client.GetAsync<List<dynamic>>(request, cancel);
        }

        public async Task<User?> GetUserById(string id, CancellationToken cancel = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var request = new RestRequest($"users/{id}");
            return await this.client.GetAsync<User>(request, cancel);
        }

        public Task UpdateUser(User user, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
