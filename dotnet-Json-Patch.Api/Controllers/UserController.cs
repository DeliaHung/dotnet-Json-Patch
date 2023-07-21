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

        [HttpPatch("")]
        public async Task<IActionResult> CommonPatch(UpdateUserCommand command)
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

            if (string.IsNullOrWhiteSpace(command.FirstName) == false)
            {
                user.FirstName = command.FirstName;
            }

            if (string.IsNullOrWhiteSpace(command.LastName) == false)
            {
                user.LastName = command.LastName;
            }


            return Ok(user);
        }

        [HttpPatch("{id:int}")]
        public IActionResult JsonPatch([FromRoute] int id ,[FromBody] JsonPatchDocument<User> command)
        {
            User? user = FackUserRepository.GetUserById(id);

            if (user == null)
                return NoContent();
            
            command.ApplyTo(user);

            return Ok(user);
        }
    }
}