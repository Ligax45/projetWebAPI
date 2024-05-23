//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ProjetWebApi.Data.DatabaseContext;
//using ProjetWebApi.Data.Entities;
//using ProjetWebApi.Models;
//using ProjetWebApi.Repositories;

//namespace ProjetWebApi.Controllers
//{
    
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly DbHelper _db;
//        private readonly UserRepository _userRepository;

//        public UserController(DataContext dataContext, UserRepository userRepository)
//        {
//            _db = new DbHelper(dataContext);
//            _userRepository = userRepository;
//        }

//        // GET: api/user
//        [HttpGet]
//        public ActionResult<IEnumerable<UtilisateurModel>> Get()
//        {
//            ResponseType type = ResponseType.Success;
//            try
//            {
//                IEnumerable<UtilisateurModel> users = _db.GetUtilisateurs();
//                if (!users.Any())
//                {
//                    type = ResponseType.NotFound;
//                }
//                return Ok(ResponseHandler.GetAppResponse(type, users));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
//            }
//        }

//        // GET api/user/5
//        [HttpGet("{id}")]
//        public ActionResult<UtilisateurModel> Get(int id)
//        {
//            ResponseType type = ResponseType.Success;
//            try
//            {
//                UtilisateurModel user = _db.GetUtilisateurById(id);
//                if (user == null)
//                {
//                    type = ResponseType.NotFound;
//                }
//                return Ok(ResponseHandler.GetAppResponse(type, user));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
//            }
//        }

//        // POST api/user
//        [HttpPost]
//        public ActionResult Post([FromBody] UtilisateurModel user)
//        {
//            try
//            {
//                ResponseType type = ResponseType.Success;
//                _db.SaveUtilisateur(user);

//                var utilisateurEntity = new Utilisateur
//                {
//                    id = user.id,
//                    email = user.email,
//                    mdp = user.mdp,
//                };
//                _userRepository.CreateUser(utilisateurEntity);

//                return CreatedAtAction(nameof(Get), new { user.id }, ResponseHandler.GetAppResponse(type, user));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
//            }
//        }

//        // PUT api/user/5
//        [HttpPut("{id}")]
//        public ActionResult Put(int id, [FromBody] UtilisateurModel user)
//        {
//            try
//            {
//                ResponseType type = ResponseType.Success;
//                user.id = id;
//                _db.SaveUtilisateur(user);

//                var utilisateurEntity = new Utilisateur
//                {
//                    id = user.id,
//                    email = user.email,
//                    mdp = user.mdp,
//                };
//                _userRepository.UpdateUser(utilisateurEntity);

//                return Ok(ResponseHandler.GetAppResponse(type, user));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
//            }
//        }

//        // DELETE api/user/5
//        [HttpDelete("{id}")]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                ResponseType type = ResponseType.Success;
//                _db.DeleteUtilisateur(id);

//                _userRepository.DeleteUser(id);

//                return Ok(ResponseHandler.GetAppResponse(type, "Suppression réussie."));
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
//            }
//        }
//    }
//}
