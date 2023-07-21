namespace dotnet_Json_Patch.Api
{
    public static class FackUserRepository
    {
        static readonly List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "pingchun.hung@gmail.com",
                Account = "delia",
                Password = "123",
                Birthday = new DateTime(1996, 03, 31),
                FirstName = "Hung",
                LastName = "Ping Chun"
            },
            new User()
            {
                Id = 2,
                Email = "david.chen@gmail.com",
                Account = "david",
                Password = "321",
                Birthday = new DateTime(1991, 08, 13),
                FirstName = "Chen",
                LastName = "David"
            },
        };

        public static User? GetUserById(int id)
        {
            return users.FirstOrDefault(_ => _.Id == id);
        }
    }
}
