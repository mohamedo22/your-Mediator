using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Configuration;
using test.Model;
using test.Dto;
using test.Interface;
using Microsoft.EntityFrameworkCore;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterRepo _repo;

        public UserController(IRegisterRepo repo)
        {
            _repo = repo;
        }
        [HttpPatch("editprof")]
        public IActionResult Update(EditProfileDto dto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            else
            {
                bool status = _repo.EditProfile(dto);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Data Modified Successfully!"
                    });
                }
                return BadRequest(new
                {
                    status,
                    message = "Invalid : Username | Phone  | address   "
                });
            }
        }
        [HttpPost("SignUp")]
        public IActionResult SignUp(UserDto registerDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            {
                bool status = _repo.SignUp(registerDto);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Account Created successfully!"
                    });
                }
                return BadRequest(new
                {
                    status,
                    message = "Invalid Data Entered"
                });
            }
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _repo.Login(loginDto); 

            if (user != null)
            {
                return Ok(new
                {
                    status = true,
                    message = "Login successful!",
                    user = user
                });
            }
            else
            {
                return NotFound(new
                {
                    status = false,
                    message = "Invalid username or password."
                });
            }
        }
        [HttpPatch]
        public IActionResult ForgetPassword(ForgetDto forgetDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            {
                bool status = _repo.ForgetPassword(forgetDto);
                if (status)
                {
                    return Ok(new
                    {
                        status = status,
                        message = "Password Changed Sucessfuly",
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        status = status,
                        message = "Invalid Email."
                    });
                }
            }

        }

    }
}


