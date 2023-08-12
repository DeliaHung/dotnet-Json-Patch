using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JsonPatch.Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = FakeUserRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPatch("{id:int}")]
        public IActionResult JsonPatch([FromRoute] int id, [FromBody] JsonPatchDocument<UpdateUserCommand> command)
        {
            var user = FakeUserRepository.GetUserById(id);

            if (user == null)
                return BadRequest();

            UpdateUserCommand dto =  _mapper.Map<UpdateUserCommand>(user);
            
            command.ApplyTo(dto);
            
            _mapper.Map(dto, user);

            //saveChange..

            return Ok(user);
        }
    }

    public static class FakeUserRepository
    {
        static readonly List<User> users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "hung",
                LastName = "pung chun",
                Age = 27,
                Birthday = new DateTime(1996, 03, 31),
                IsNewsletterSubscribed = true,
                EmailList = new List<string>() 
                { 
                    "pingchun.hung@gmail.com", 
                    "jyun87123@gmail.com" 
                },
                ShippingAddresses = new List<ShippingAddress>
                {
                    new ShippingAddress { ZipCode = "001", Address = "台北市內湖區文德路87號" },
                    new ShippingAddress { ZipCode = "001", Address = "台北市板橋區四維路123號" }
                }
            }
        };

        public static User? GetUserById(int id)
        {
            return users.FirstOrDefault(f => f.Id == id);
        }
    }
}