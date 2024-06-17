using Microsoft.AspNetCore.Mvc;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Models;
using ProjetWebApi.Repositories;

namespace ProjetWebApi.Controllers
{
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly DbHelper _db;
        private readonly UserRepository _userRepository;

        public UtilisateurController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
            _userRepository = new UserRepository();
        }

        [HttpGet]
        [Route("api/[controller]/GetAllUtilisateurs")]
        public IActionResult GetAllUtilisateur()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UtilisateurModel> data = _db.GetAllUtilisateurs();
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
                UtilisateurModel data = _db.GetUtilisateurById(id);

                if (data == null)
                {
                    Utilisateur utilisateur = _userRepository.GetUser(id);
                    if (utilisateur == null)
                    {
                        return NotFound();
                    }

                    data = new UtilisateurModel
                    {
                        Id = utilisateur.Id,
                        Email = utilisateur.Email,
                        Password = utilisateur.Password,
                        Salt = utilisateur.Salt,
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
        [Route("api/[controller]/CreateUtilisateur")]
        public IActionResult CreateUtilisateur([FromBody] UtilisateurModel model)
        {
            try
            {
                // Logique de sauvegarde de la Bdd PostgreSQL
                string salt;
                model.Password = PasswordHasher.HashPassword(model.Password, out salt);
                _db.CreateUtilisateur(model, salt);

                // Logique de sauvegarde dans Redis
                var utilisateurEntity = new Utilisateur
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
        [Route("api/[controller]/UpdateUtilisateur")]
        public IActionResult UpdateUtilisateur([FromBody] UtilisateurModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                string salt;
                model.Password = PasswordHasher.HashPassword(model.Password, out salt);
                _db.UpdateUtilisateur(model, salt);

                var utilisateurEntity = new Utilisateur
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    Salt = salt,
                };
                _userRepository.UpdateUser(utilisateurEntity);

                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteUtilisateur/{id}")]
        public IActionResult DeleteUtilisateur(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUtilisateur(id);
                _userRepository.DeleteUser(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Suppression réussie."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
