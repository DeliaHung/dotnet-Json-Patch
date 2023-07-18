using Microsoft.AspNetCore.Mvc;

namespace dotnet_Json_Patch.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [http]

        [HttpPost()]
        public IActionResult AddUser(User user)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult AddUser([FromRoute] Guid id, [FromBody] User user)
        {
            return Ok();
        }
        [HttpPatch()]
        public IActionResult AddUser(User user)
        {
            return Ok();
        }
        [HttpPost()]
        public IActionResult AddUser(User user)
        {
            return Ok();
        }
    }
}