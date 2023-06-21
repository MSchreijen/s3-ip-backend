using BLL.Interfaces;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : Controller
    {
        private IUserLogic userLogic;

        public UserController(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return userLogic.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById(int id)
        {
            User? user = userLogic.GetUserById(id);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (user != null)
            {
                bool success = userLogic.AddUser(user);
                if (success) { return NoContent(); }
                else return BadRequest();
            }
            else return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            if (user != null)
            {
                bool success = userLogic.UpdateUser(user);
                if (success) { return NoContent(); }
                else return BadRequest();
            }
            else return BadRequest();
        }

        [HttpPost]
        [Route("{userId}/playlist/{playlistId}")]
        public IActionResult AddPlaylistToUser(int userId, int playlistId)
        {
            if (userLogic.AddPlaylistToUser(userId, playlistId))
            {
                return Ok(new { message = "tracks added" });
            }
            else return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteUser(User user)
        {
            if(user == null) return BadRequest();
            userLogic.DeleteUser(user);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUserById(int id)
        {
            bool success = userLogic.DeleteUserById(id);
            if (success) { return NoContent(); }
            else return BadRequest();
        }
    }
}
