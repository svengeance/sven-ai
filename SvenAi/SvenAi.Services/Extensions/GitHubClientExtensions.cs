using System;
using System.Text.Json;
using System.Threading.Tasks;
using Octokit;
using SvenAi.Core.Git;

namespace SvenAi.Services.Extensions
{
    public static class GitHubClientExtensions
    {
        public static Task<IApiResponse<string>> GetAllUserEventsRaw(this GitHubClient client, string userName) =>
            client.Connection.GetHtml(new Uri($"users/{userName}/events", UriKind.Relative));

        // Admittedly doing a bit too much here.
        public static async Task<string> ExtractProperty(this GitHubClient client, string link, string htmlPath) =>
            JsonDocument.Parse((await client.Connection.GetHtml(new Uri(link, UriKind.Absolute))).Body).RootElement
                        .GetProperty(htmlPath)
                        .GetString();
    }
}