using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailSenderApi.Dtos;
using EmailSenderApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;
        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmailDto value)
        {
            _emailRepository.SendEmail(value);
            return Ok();
        }
    }
}
