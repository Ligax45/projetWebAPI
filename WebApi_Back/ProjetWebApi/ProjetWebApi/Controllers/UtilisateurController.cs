using Microsoft.AspNetCore.Mvc;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Models;

namespace ProjetWebApi.Controllers
{
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly DbHelper _db;
        public UtilisateurController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }


        // GET: api/<UtilisateurController>
        [HttpGet]
        [Route("api/[controller]/GetUtilisateurs")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<UtilisateurModel> data = _db.GetUtilisateurs();
                if(!data.Any())
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

        // GET api/<UtilisateurController>/5
        [HttpGet]
        [Route("api/[controller]/GetUtilisateurById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UtilisateurModel data = _db.GetUtilisateurById(id);
                if (data == null)
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

        // POST api/<UtilisateurController>
        [HttpPost]
        [Route("api/[controller]/SaveUtilisateur")]
        public IActionResult Post([FromBody] UtilisateurModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUtilisateur(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<UtilisateurController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateUtilisateur")]
        public IActionResult Put([FromBody] UtilisateurModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveUtilisateur(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<UtilisateurController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteUtilisateur/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteUtilisateur(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Suppression réussie."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
