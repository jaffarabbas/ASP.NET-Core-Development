using GitCommiterApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitCommiterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitController : ControllerBase
    {
        private readonly IGitRepository _gitRepository;

        public GitController(IGitRepository git)
        {
            this._gitRepository = git;
        }

        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            var data = await _gitRepository.gitRepositoryList();
            return Ok(data);
        }
    }
}
