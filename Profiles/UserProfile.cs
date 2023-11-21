using AutoMapper;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;

namespace ECommAPIAssessment.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

        }
    }
}
