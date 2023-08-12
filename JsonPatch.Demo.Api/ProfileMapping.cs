using AutoMapper;

namespace JsonPatch.Demo.Api
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping() 
        {
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<ShippingAddress, UpdateUserShippingAddress>().ReverseMap();
        }
    }
}
