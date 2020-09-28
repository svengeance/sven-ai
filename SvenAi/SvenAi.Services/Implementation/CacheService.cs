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
using SvenAi.Core;
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
                DateTimeOffset.Now.AddMinutes(5));

        public async Task<List<GitActivityItemViewModel>> GetCachedGitActivity(string userName) =>
            await _appCache.GetOrAddAsync(
                $"GitActivity_{userName}",
                async () =>
                {
                    var client = _gitClientFactory.CreateClient();
                    var rawActivities = await client.GetAllUserEventsRaw(userName);
                    var activities = ReadActivityJson(rawActivities.Body);

                    // Because Git returns some data as API links to other data, we must hydrate the ViewModels with human-readable data
                    foreach (var activity in activities)
                    {
                        if (activity.Action.Link.Contains("api.github.com"))
                        {
                            var realHtmlUrl = await _appCache.GetOrAddAsync(activity.Action.Link, async () => await client.ExtractProperty(activity.Action.Link, activity.ApiHtmlUrlPath));
                            activity.Action.Link = realHtmlUrl;
                        }

                        if (activity.Repo.Url.Contains("api.github.com"))
                            activity.Repo.Url = await _appCache.GetOrAddAsync(activity.Repo.Url, async () => await client.ExtractProperty(activity.Repo.Url, SvenAiConstants.GitApi.RepositoryHtmlUrlPropertyPath));
                    }

                    return activities;
                }, DateTimeOffset.Now.AddMinutes(30));

        private List<GitActivityItemViewModel> ReadActivityJson(string activityJson) =>
            JsonDocument.Parse(activityJson).RootElement
                        .EnumerateArray()
                        .Select(GitActivityItemViewModel.FromJsonElement)
                        .ToList();

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