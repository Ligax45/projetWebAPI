<<<<<<< HEAD
﻿//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProjetWebApi.Data.Entities;
//using ProjetWebApi.Repositories;

//namespace ProjetWebApi.Controllers
//{
//    public class TesteRedis : ControllerBase
//    {
//        private readonly UserRepository _userRepository;

//        public TesteRedis()
//        {
//            _userRepository = new UserRepository();
//        }

//        // GET api/user/5
//        [HttpGet("{id}")]
//        public ActionResult<Utilisateur> Get(int id)
//        {
//            var user = _userRepository.GetUser(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return Ok(user);
//        }

//        // POST api/user
//        [HttpPost("create")]
//        public ActionResult CreateRedisUser([FromBody] Utilisateur user)
//        {
//            _userRepository.CreateUser(user);
//            return CreatedAtAction(nameof(Get), new { user.Id }, user);
//        }

//        // PUT api/user/5
//        [HttpPut("{id}")]
//        public ActionResult Put(int id, [FromBody] Utilisateur user)
//        {
//            var existingUser = _userRepository.GetUser(id);
//            if (existingUser == null)
//            {
//                return NotFound();
//            }
//            user.Id = id;
//            _userRepository.UpdateUser(user);
//            return NoContent();
//        }

//        // DELETE api/user/5
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            var existingUser = _userRepository.GetUser(id);
//            if (existingUser == null)
//            {
//                return NotFound();
//            }
//            _userRepository.DeleteUser(id);
//            return NoContent();
//        }
//    }
//}
=======
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Repositories;

namespace ProjetWebApi.Controllers
{
    public class TesteRedis : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public TesteRedis()
        {
            _userRepository = new UserRepository();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<Utilisateur> Get(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost("create")]
        public ActionResult CreateRedisUser([FromBody] Utilisateur user)
        {
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(Get), new { user.id }, user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Utilisateur user)
        {
            var existingUser = _userRepository.GetUser(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            user.id = id;
            _userRepository.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingUser = _userRepository.GetUser(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
