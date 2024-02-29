
using HealthTech331.Models;
using HealthTech331.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace HealthTech331.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryUser _userRepository;

        public UserController(IRepositoryUser userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(_userRepository));   
        }

        [HttpGet]
        public ActionResult<List<ApplicationUser>> GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {

                var _user =await _userRepository.GetById(id);
                if(_user == null)
                {
                    return NotFound();
                }
                _userRepository.Delete(_user);
                return NoContent();

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<ApplicationUser>  GetById(int id)
        {
            var u = _userRepository.GetById(id);
            return Ok(u);
        }


        

    }
}
