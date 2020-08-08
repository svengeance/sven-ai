using Octokit;
using SvenAi.Core;
using SvenAi.Services.Interface;

namespace SvenAi.Services.Implementation
{
    public class GitClientFactory : IGitClientFactory
    {
        private readonly AccessTokens _accessTokens;

        public GitClientFactory(AccessTokens accessTokens)
        {
            _accessTokens = accessTokens;
        }

        public GitHubClient CreateClient() => new GitHubClient(new ProductHeaderValue("SvenAi"))
        {
            Credentials = new Credentials(_accessTokens.GitHub)
        };
    }
}