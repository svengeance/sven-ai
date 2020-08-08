using System;
using System.Threading.Tasks;
using Octokit;

namespace SvenAi.Services.Extensions
{
    public static class GitHubClientExtensions
    {
        public static async Task<IApiResponse<string>> GetAllUserEventsRaw(this GitHubClient client, string userName) =>
            await client.Connection.GetHtml(new Uri($"users/{userName}/events", UriKind.Relative));
    }
}