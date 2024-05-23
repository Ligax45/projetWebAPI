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
        [Route("api/[controller]/GetUtilisateurs")]
        public IActionResult GetAllUtilisateur()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UtilisateurModel> data = _db.GetUtilisateurs();
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
        [Route("api/[controller]/GetUtilisateurById/{id}")]
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
                        id = utilisateur.id,
                        email = utilisateur.email,
                        mdp = utilisateur.mdp
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
        [Route("api/[controller]/SaveUtilisateur")]
        public IActionResult PostUtilisateur([FromBody] UtilisateurModel model)
        {
            try
            {
                // Logique de sauvegarde de la Bdd PostgreSQL
                _db.SaveUtilisateur(model);

                // Logique de sauvegardedans Redis
                var utilisateurEntity = new Utilisateur
                {
                    id = model.id,
                    email = model.email,
                    mdp = model.mdp,
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
        public IActionResult PutUtilisateur([FromBody] UtilisateurModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUtilisateur(model);

                var utilisateurEntity = new Utilisateur
                {
                    id = model.id,
                    email = model.email,
                    mdp = model.mdp,
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
