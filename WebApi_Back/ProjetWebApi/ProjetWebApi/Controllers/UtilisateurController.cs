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
<<<<<<< HEAD
        [Route("api/[controller]/GetAllUtilisateurs")]
=======
        [Route("api/[controller]/GetUtilisateurs")]
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        public IActionResult GetAllUtilisateur()
        {
            ResponseType type = ResponseType.Success;
            try
            {
<<<<<<< HEAD
                IEnumerable<UtilisateurModel> data = _db.GetAllUtilisateurs();
=======
                IEnumerable<UtilisateurModel> data = _db.GetUtilisateurs();
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
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
<<<<<<< HEAD
        [Route("api/[controller]/GetById/{id}")]
=======
        [Route("api/[controller]/GetUtilisateurById/{id}")]
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
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
<<<<<<< HEAD
                        Id = utilisateur.Id,
                        Email = utilisateur.Email,
                        Password = utilisateur.Password,
                        Salt = utilisateur.Salt,
=======
                        id = utilisateur.id,
                        email = utilisateur.email,
                        mdp = utilisateur.mdp
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
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
<<<<<<< HEAD
        [Route("api/[controller]/CreateUtilisateur")]
        public IActionResult CreateUtilisateur([FromBody] UtilisateurModel model)
=======
        [Route("api/[controller]/SaveUtilisateur")]
        public IActionResult PostUtilisateur([FromBody] UtilisateurModel model)
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        {
            try
            {
                // Logique de sauvegarde de la Bdd PostgreSQL
<<<<<<< HEAD
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
=======
                _db.SaveUtilisateur(model);

                // Logique de sauvegardedans Redis
                var utilisateurEntity = new Utilisateur
                {
                    id = model.id,
                    email = model.email,
                    mdp = model.mdp,
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
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
<<<<<<< HEAD
        public IActionResult UpdateUtilisateur([FromBody] UtilisateurModel model)
=======
        public IActionResult PutUtilisateur([FromBody] UtilisateurModel model)
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        {
            try
            {
                ResponseType type = ResponseType.Success;
<<<<<<< HEAD
                string salt;
                model.Password = PasswordHasher.HashPassword(model.Password, out salt);
                _db.UpdateUtilisateur(model, salt);

                var utilisateurEntity = new Utilisateur
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    Salt = salt,
=======
                _db.SaveUtilisateur(model);

                var utilisateurEntity = new Utilisateur
                {
                    id = model.id,
                    email = model.email,
                    mdp = model.mdp,
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
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
