using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Repositories;

namespace ProjetWebApi.Controllers
{
    public class TesteRedis : ControllerBase
    {
        private readonly UserRepositoryRedis _userRepository;

        public TesteRedis()
        {
            _userRepository = new UserRepositoryRedis();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost("create")]
        public ActionResult CreateRedisUser([FromBody] User user)
        {
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(Get), new { user.Id }, user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            user.Id = id;
            _userRepository.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
