using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LazyCache;
using Microsoft.VisualBasic;
using Octokit;
using SvenAi.Core.Git;
using SvenAi.Services.Extensions;
using SvenAi.Services.Interface;

namespace SvenAi.Services.Implementation
{
    public class CacheService : ICacheService
    {
        private readonly IAppCache _appCache;
        private readonly IGitClientFactory _gitClientFactory;

        public CacheService(IAppCache appCache, IGitClientFactory gitClientFactory)
        {
            _appCache = appCache;
            _gitClientFactory = gitClientFactory;
        }

        public async Task<GitUserViewModel> GetCachedGitUser(string userName)
            => await _appCache.GetOrAddAsync(
                $"GitUser_{userName}",
                async () => MapToGitUserViewModel(await _gitClientFactory.CreateClient().User.Current()), 
                DateTimeOffset.Now.AddMinutes(1));

        public async Task<List<GitActivityItemViewModel>> GetCachedGitActivity(string userName)
        {
            var data = await _appCache.GetOrAddAsync(
                $"GitActivity_{userName}",
                async () =>
                {
                    var client = _gitClientFactory.CreateClient();
                    var rawActivities = await client.GetAllUserEventsRaw(userName);
                    var activities = ReadActivityJson(rawActivities.Body);

                    return activities;
                });

            return data;
        }

        private List<GitActivityItemViewModel> ReadActivityJson(string activityJson)
        {
            var jdoc = JsonDocument.Parse(activityJson);
            var result = jdoc.RootElement
                             .EnumerateArray()
                             .Select(GitActivityItemViewModel.FromJsonElement)
                             .ToList();

            return result;
        }

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