using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Models;
using ProjetWebApi.Repositories;
using ProjetWebApi.Services;
using ProjetWebApi.Utilities;

namespace ProjetWebApi.Controllers
{
    public class ProfileController : ControllerBase
    {
        private readonly DbHelper _db;
        private readonly ProfilRepositoryRedis _profilRepository;

        public ProfileController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
            _profilRepository = new ProfilRepositoryRedis();
        }

        [HttpGet]
        [Route("api/[controller]/GetAllProfile")]
        public IActionResult GetAllProfile()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProfileModel> data = _db.GetAllProfiles();
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

        [HttpPost]
        [Route("api/[controller]/CreateProfile")]
        public IActionResult CreateProfile([FromBody] ProfileModel model)
        {
            try
            {
                _db.CreateProfile(model);

                // Logique de sauvegarde dans Redis
                var profilEntity = new Profile
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    User = new User { Id = model.UserId }

                };
                _profilRepository.CreateProfil(profilEntity);

                return Ok(ResponseHandler.GetAppResponse(ResponseType.Success, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPut]
        [Route("api/[controller]/UpdateProfile")]
        public IActionResult UpdateProfile([FromBody] ProfileModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateProfile(model);

                Profile profilEntity = new Profile
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    User = new User { Id = model.UserId }
                };
                _profilRepository.UpdateProfil(profilEntity);

                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteProfile/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteProfile(id);
                _profilRepository.DeleteProfil(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Suppression réussie."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
