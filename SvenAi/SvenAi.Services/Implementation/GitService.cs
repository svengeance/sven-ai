using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using SvenAi.Core;
using SvenAi.Core.Git;
using SvenAi.Services.Interface;

namespace SvenAi.Services.Implementation
{
    public class GitService : IGitService
    {
        private readonly ICacheService _cacheService;

        public GitService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<GitUserViewModel> GetUserInformation(string userName) => await _cacheService.GetCachedGitUser(userName);

        public async Task<List<GitActivityItemViewModel>> GetUserActivity(string userName) => await _cacheService.GetCachedGitActivity(userName);
    }
}