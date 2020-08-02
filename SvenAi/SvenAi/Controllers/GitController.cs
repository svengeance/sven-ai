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

        [HttpGet("User/{userName}/About")]
        public async Task<IActionResult> GetUserProfileInformation(string userName) => Ok(await _gitService.GetUserInformation(userName));
    }
}