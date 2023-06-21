using DTO;

namespace DAL.Interfaces
{
    public interface IUserHandler
    {
        bool AddUser(User user);
        void DeleteUser(User user);
        bool DeleteUserById(int id);
        User? GetUserById(int id);
        List<User> GetAllUsers();
        bool UpdateUser(User user);
    }
}