﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using SvenAi.Core.Git;
using SvenAi.Services.Implementation;

namespace SvenAi.Services.Interface
{
    public interface IGitService
    {
        Task<GitUserViewModel> GetUserInformation(string userName);
        Task<List<GitActivityItemViewModel>> GetUserActivity(string userName);
    }
}