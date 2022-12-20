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
        //private readonly ITest test;
        public GitController(IGitRepository git)
        {
            this._gitRepository = git;
            //this.test = git;
        }

        [HttpGet("repositories")]
        public async Task<ActionResult> GetData()
        {
            var data = await _gitRepository.gitRepositoryList();
            //var data = await test.data();
            return Ok(data);
        }

        [HttpGet("stagefile")]
        public async Task<ActionResult> GetStaggingList(string path)
        {
            var data = await _gitRepository.staggingfileList(path);
            return Ok(data);
        }
    }
}
