using Microsoft.AspNetCore.Mvc;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Models;
using ProjetWebApi.Repositories;
using ProjetWebApi.Services;
using ProjetWebApi.Utilities;

namespace ProjetWebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbHelper _db;
        private readonly UserRepositoryRedis _userRepository;

        public UserController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
            _userRepository = new UserRepositoryRedis();
        }

        [HttpGet]
        [Route("api/[controller]/GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UserModel> data = _db.GetAllUsers();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                UserModel data = _db.GetUserById(id);

                if (data == null)
                {
                    User user = _userRepository.GetById(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    data = new UserModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Password = user.Password,
                        Salt = user.Salt,
                    };
                }

                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/CreateUser")]
        public IActionResult CreateUser([FromBody] UserModel model)
        {
            try
            {
                // Logique de sauvegarde de la Bdd PostgreSQL
                string salt;
                model.Password = PasswordHasher.HashPassword(model.Password, out salt);
                _db.CreateUser(model, salt);

                // Logique de sauvegarde dans Redis
                var utilisateurEntity = new User
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    Salt = salt,
                };
                _userRepository.CreateUser(utilisateurEntity);

                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                string salt;
                model.Password = PasswordHasher.HashPassword(model.Password, out salt);
                _db.UpdateUser(model, salt);

                var utilisateurEntity = new User
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    Salt = salt,
                };
                //_userRepository.UpdateUser(utilisateurEntity);

                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUser(id);
                //_userRepository.DeleteUser(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Suppression réussie."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
