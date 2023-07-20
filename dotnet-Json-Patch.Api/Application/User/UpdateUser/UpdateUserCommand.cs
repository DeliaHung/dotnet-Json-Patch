namespace dotnet_Json_Patch.Api.Application.User.UpdateUserCommand
{
    public class UpdateUserCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
    }
}
