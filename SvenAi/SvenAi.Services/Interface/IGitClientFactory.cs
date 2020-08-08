using Octokit;

namespace SvenAi.Services.Interface
{
    public interface IGitClientFactory
    {
        GitHubClient CreateClient();
    }
}