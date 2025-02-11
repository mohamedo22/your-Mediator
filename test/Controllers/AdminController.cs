using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Dto;
using test.Interface;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin adminRepo;

        public AdminController(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }
        [HttpPut]
        public IActionResult ForgetPassword(ForgetDto forgetDto)
        {
            if (adminRepo.ForgetPassword(forgetDto))
            {
                return Ok();
            }
            return Ok();
        }
        [HttpPost("register")]
        public IActionResult SignUp(AdminDTO adminDTO)
        {
            if (adminRepo.SignUp(adminDTO))
            {
                return Ok();
            }
            return Ok();
        }
        [HttpPost("login")]
        public IActionResult Login(AdminDTO adminDTO)
        {
            if (adminRepo.Login(adminDTO))
            {
                return Ok();
            }
              return Ok();
        }
    }
}
