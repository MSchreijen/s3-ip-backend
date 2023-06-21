using DTO;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        void DeleteUser(User user);
        bool DeleteUserById(int id);
        User? GetUserById(int id);
        List<User> GetAllUsers();
        bool UpdateUser(User user);
        bool AddPlaylistToUser(int userId, int playlistId);
    }
}