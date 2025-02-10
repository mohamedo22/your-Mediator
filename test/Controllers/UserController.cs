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
                    return Accepted(new
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
                    return Accepted(new
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
        public IActionResult Login(LoginDto logindto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            {
                bool status = _repo.Login(logindto);
                if (status)
                {

                    return Accepted(new
                    {
                        status = status,
                        message = "Login successful!",
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        status = status,
                        message = "Invalid username or password."
                    });
                }
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
                    return Accepted(new
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


