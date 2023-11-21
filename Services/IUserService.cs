using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public interface IUserService
    {
        User GetUserById(string userid);
        ResultModel AddUser(User user);
        ResultModel DeleteUser(string userid);
        ResultModel UpdateUser(User user);
        User ValidteUser(string email, string password);
    }
}
