using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class UserHandler : IUserHandler
    {
        private readonly MergerContext mergerContext;

        public UserHandler(MergerContext mergerContext)
        {
            this.mergerContext = mergerContext;
        }

        public List<User> GetAllUsers()
        {
            return mergerContext.Users.Include(u => u.Playlists).ToList();
        }

        public User? GetUserById(int id)
        {
            return mergerContext.Users.Find(id);
        }

        public bool AddUser(User user)
        {
            mergerContext.Users.Add(user);
            int modifiedEntries = mergerContext.SaveChanges();
            if (modifiedEntries > 0) { return true; }
            return false;
        }

        public bool UpdateUser(User user)
        {
            User? toUpdate = mergerContext.Users.Find(user.Id);

            if (toUpdate != null)
            {
                toUpdate.Name = user.Name;
                toUpdate.SpotifyId = user.SpotifyId;
                toUpdate.Playlists = user.Playlists;
                mergerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteUserById(int id)
        {
            User? toDelete = mergerContext.Users.Find(id);
            if (toDelete != null)
            {
                mergerContext.Users.Remove(toDelete);
                mergerContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteUser(User user)
        {
            mergerContext.Remove(user);
            mergerContext.SaveChanges();
        }
    }
}
