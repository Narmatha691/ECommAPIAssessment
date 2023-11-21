using AutoMapper;
using ECommAPIAssessment.Database;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public class UserService : IUserService
    {
        private readonly MyContext context;

        public UserService(MyContext context)
        {
            this.context = context;
        }

        public ResultModel AddUser(User user)
        {
            try
            {
                if (context.Users.Any(u => u.UserId == user.UserId))
                {
                    return new ResultModel { Success = false, Message = "User with the same ID already exists." };
                }
                if (context.Users.Any(u => u.UserEmail == user.UserEmail))
                {
                    return new ResultModel { Success = false, Message = "User with the same email already exists." };
                }
                context.Users.Add(user);
                context.SaveChanges();
                return new ResultModel { Success = true, Message = "User added successfully." };
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public ResultModel DeleteUser(string userid)
        {
            try
            {
                User user = context.Users.Find(userid);

                if (user != null)
                {
                    context.Remove(user);
                    context.SaveChanges();

                    return new ResultModel { Success = true, Message = "User deleted successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "User not found." };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public User GetUserById(string userid)
        {
            try
            {
                return context.Users.Find(userid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultModel UpdateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    context.Users.Update(user);
                    context.SaveChanges();
                    return new ResultModel { Success = true, Message = "User edited successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "User not found." };
                }
            }
            catch (Exception ex)
            {

                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public User ValidteUser(string email, string password)
        {
            return context.Users.SingleOrDefault(u => u.UserEmail == email && u.Password == password);

        }
    }
}
