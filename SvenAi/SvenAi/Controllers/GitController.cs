using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SvenAi.Services.Implementation;
using SvenAi.Services.Interface;

namespace SvenAi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitService _gitService;

        public GitController(IGitService gitService)
        {
            _gitService = gitService;
        }

        [HttpGet("Users/Me")]
        public async Task<IActionResult> GetUserProfileInformation() => Ok(await _gitService.GetUserInformation("svengeance"));

        [HttpGet("Users/Me/Activity")]
        public async Task<IActionResult> GetUserActivity() => Ok((await _gitService.GetUserActivity("svengeance")).ToList());
    }
}