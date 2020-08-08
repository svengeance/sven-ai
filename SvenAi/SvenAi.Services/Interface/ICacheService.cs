using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using SvenAi.Core.Git;
using SvenAi.Services.Implementation;

namespace SvenAi.Services.Interface
{
    public interface ICacheService
    {
        Task<GitUserViewModel> GetCachedGitUser(string userName);
        Task<List<GitActivityItemViewModel>> GetCachedGitActivity(string userName);
    }
}