using BLL.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserHandler userHandler;
        private IPlaylistLogic playlistLogic;

        public UserLogic(IUserHandler userHandler, IPlaylistLogic playlistLogic)
        {
            this.userHandler = userHandler;
            this.playlistLogic = playlistLogic;
        }

        public List<User> GetAllUsers()
        {
            return userHandler.GetAllUsers();
        }

        public User? GetUserById(int id)
        {
            return userHandler.GetUserById(id);
        }

        public bool AddUser(User user)
        {
            return userHandler.AddUser(user);
        }

        public bool UpdateUser(User user)
        {
            return userHandler.UpdateUser(user);
        }

        public bool DeleteUserById(int id)
        {
            return userHandler.DeleteUserById(id);
        }

        public void DeleteUser(User user)
        {
            userHandler.DeleteUser(user);
        }

        public bool AddPlaylistToUser(int userId, int playlistId)
        {
            User? toUpdate = GetUserById(userId);
            Playlist? toAdd = playlistLogic.GetPlaylistById(playlistId);
            if (toUpdate != null && toAdd != null)
            {
                toUpdate.Playlists.Append(toAdd);
                userHandler.UpdateUser(toUpdate);
                return true;
            }
            return false;
        }
    }
}
