using System.Threading.Tasks;
using Octokit;
using SvenAi.Core;
using SvenAi.Core.Git;
using SvenAi.Services.Interface;

namespace SvenAi.Services.Implementation
{
    public class GitService : IGitService
    {
        private readonly GitHubClient _client;
        public GitService(AccessTokens accessTokens)
        {
            _client = new GitHubClient(new ProductHeaderValue("SvenAi"));
            _client.Credentials = new Credentials(accessTokens.GitHub);
        }

        public async Task<GitUserViewModel> GetUserInformation(string userName) => MapToGitUserViewModel(await _client.User.Get(userName));

        private static GitUserViewModel MapToGitUserViewModel(User user) =>
            new GitUserViewModel
            {
                AvatarUrl = user.AvatarUrl,
                Bio = user.Bio,
                Blog = user.Blog,
                Hireable = user.Hireable,
                HtmlUrl = user.HtmlUrl,
                NumPrivateRepos = user.TotalPrivateRepos,
                NumPublicRepos = user.PublicRepos,
                NumPrivateGists = user.PrivateGists,
                NumPublicGists = user.PublicGists,
                Url = user.Url
            };
    }
}