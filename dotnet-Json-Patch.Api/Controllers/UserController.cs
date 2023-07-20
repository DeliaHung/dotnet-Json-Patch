using dotnet_Json_Patch.Api.Application.User.UpdateUserCommand;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = new()
            {
                Id = 1,
                Email = "pingchun.hung@gmail.com",
                Account = "delia",
                Password = "123",
                Birthday = new DateTime(1996, 03, 31),
                FirstName = "hung",
                LastName = "pung chun"
            };
            return Ok(user);
        }


        [HttpPost()]
        public async Task<IActionResult> CreateUser(User user)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUserInfo(User user)
        {
            return Ok();
        }

        //[HttpPatch()]
        //public async Task<IActionResult> CommonPatch(UpdateUserCommand command)
        //{
        //    User user = new()
        //    {
        //        Id = 1,
        //        Email = "pingchun.hung@gmail.com",
        //        Account = "delia",
        //        Password = "123",
        //        Birthday = new DateTime(1996, 03, 31),
        //        FirstName = "hung",
        //        LastName = "pung chun"
        //    };

        //    if (string.IsNullOrWhiteSpace(command.FirstName) == false)
        //    {
        //        user.FirstName = command.FirstName;
        //    }

        //    if (string.IsNullOrWhiteSpace(command.LastName) == false)
        //    {
        //        user.LastName = command.LastName;
        //    }


        //    return Ok(user);
        //}

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> JsonPatch([FromBody] JsonPatchDocument<UpdateUserCommand> command)
        {
            User user = new()
            {
                Id = 1,
                Email = "pingchun.hung@gmail.com",
                Account = "delia",
                Password = "123",
                Birthday = new DateTime(1996, 03, 31),
                FirstName = "hung",
                LastName = "pung chun"
            };

            command.ApplyTo(user);

            return Ok(user);
        }
    }
}