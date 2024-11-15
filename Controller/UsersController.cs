using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiskTrack.Data;
using RiskTrack.DTOs;
using RiskTrack.Models;

namespace RiskTrack.Controller {

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private readonly IMapper _mapper;
        private readonly IUserRepo _repo;

        public UsersController(IMapper mapper, IUserRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDTO> GetUserById(int id)
        {
            var userItem = _repo.GetUserById(id);
            if (userItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadDTO>(userItem));
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUser(UserCreateDTO userCreateDTO)
        {
            var userModel = _mapper.Map<User>(userCreateDTO);
            _repo.CreateUser(userModel);
            _repo.SaveChanges();
            var userReadDTO = _mapper.Map<UserReadDTO>(userModel);
            return CreatedAtRoute(nameof(GetUserById), new { id = userReadDTO.Id }, userReadDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userFromRepo = _repo.GetUserById(id);
            if (userFromRepo == null)
            {
                return NotFound();
            }

            _repo.DeleteUser(userFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            if (_repo.IsUser(email, password))
            {
                var user = _repo.GetUserByEmailAndPassword(email, password);
                return Ok(new { success = true, userId = user.Id });
            }
            return Unauthorized();
        }
    }


}