using AutomaperExampleApp.Models;
using AutomaperExampleApp.ViewModels;
using AutoMapper;

namespace AutomaperExampleApp.MapConfigs
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {          
          CreateMap<User, UserViewModel>()
              .ForMember("Name", opt => 
                   opt.MapFrom(c => $"{c.Name}, mailo: {c.Email}"));
        }
    }
}
