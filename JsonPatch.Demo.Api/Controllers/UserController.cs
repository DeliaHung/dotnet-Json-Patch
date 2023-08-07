using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JsonPatch.Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = FakeUserRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUserInfo(User user)
        {
            //Automapper
            //Update
            //SaveChange..
            return Ok();
        }

        //[HttpPatch("{id:guid}")]
        //public async Task<IActionResult> CommonPatch([FromRoute] int id, [FromBody] User command)
        //{
        //    var user = FakeUserRepository.GetUserById(id);

        //    if (user == null)
        //        return BadRequest();

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

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> JsonPatch([FromRoute] int id, [FromBody] JsonPatchDocument<User> command)
        {
            var user = FakeUserRepository.GetUserById(id);
            
            if (user == null)
                return BadRequest();

            command.ApplyTo(user);
            
            return Ok(user);
        }
    }

    public static class FakeUserRepository
    {
        static readonly List<User> users = new List<User>()
        {
            new User
            {
                Id = 1,
                Email = "pingchun.hung@gmail.com",
                Account = "delia",
                Password = "123",
                Birthday = new DateTime(1996, 03, 31),
                FirstName = "hung",
                LastName = "pung chun",
                EmailList = new List<string>() { "pingchun.hung@gmail.com", "jyun87123@gmail.com" },
                ShippingAddresses = new List<ShippingAddress>
                {
                    new ShippingAddress { ZipCode = "001", Address = "台北市內湖區文德路87號" }
                }
            }
        };

        public static User? GetUserById(int id)
        {
            return users.FirstOrDefault(f => f.Id == id);
        }
    }
}