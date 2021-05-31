using Octokit;
using Octokit.Internal;

namespace GitReleaseManager.IntegrationTests
{
    public static class ClientBuilder
    {
        private static HttpClientAdapter _httpClient;

        public static GitHubClient Build()
        {
            var credentialStore = new InMemoryCredentialStore(Helper.Credentials);

            _httpClient = new HttpClientAdapter(HttpMessageHandlerFactory.CreateDefault);

            var connection = new Connection(
                new ProductHeaderValue("GitReleaseManager"),
                GitHubClient.GitHubApiUrl,
                credentialStore,
                _httpClient,
                new SimpleJsonSerializer());

            return new GitHubClient(connection);
        }

        public static void Cleanup()
        {
            _httpClient?.Dispose();
            _httpClient = null;
        }
    }
}