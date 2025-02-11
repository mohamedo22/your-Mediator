using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Configuration;
using test.Dto;
using test.Interface;
using test.Model;

namespace test.Repos
{
    public class RegisterRepo : IRegisterRepo
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public RegisterRepo(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public bool EditProfile(EditProfileDto editProfileDto)
        {
            var status = false;
            if (editProfileDto.Email != null)
            {
                var user = _context.User.FirstOrDefault(x => x.Email == x.Email);
                if (user != null)
                {
                    user.Phone = editProfileDto.Phone;
                    user.Username = editProfileDto.Username;
                    user.Address = editProfileDto.Address;
                    _context.User.Update(user);
                    _context.SaveChanges();
                    status = true;
                    return status;
                }
                else
                {
                    status = false;
                    return status;
                }
            }
            return false;
        }
        public bool ForgetPassword(ForgetDto forgetDto)
        {
              if (_context.User != null)
            {
                var status = false;
                var user = _context.User.FirstOrDefault(x => x.Email == forgetDto.Email);
                if (user != null)
                {
                    user.Password = forgetDto.New_Password;
                    _context.User.Update(user);
                    _context.SaveChanges();
                    status = true;
                    return status;
                }
                else
                {
                    status = false;
                    return status;
                }
            }
            return false;
        }
        public UsersDto? Login(LoginDto loginDto)
        {
            if (_context.User != null)
            {
                var user = _context.User.FirstOrDefault(x => x.Username == loginDto.Username && x.Password == loginDto.Password);
                if (user != null)
                {
                    var token = _tokenService.GenerateToken(user.UserId.ToString(), user.Username);

                    return new UsersDto
                    {
                        Id = user.UserId,
                        Username = user.Username,
                        National_Id = user.National_Id,
                        BirthDate = user.BirthDate,
                        Phone = user.Phone,
                        Email = user.Email,
                        Address = user.Address,
                        Token = token
                    };
                }
            }
            return null;
        }
        public bool SignUp(UserDto registerDto)
        {
            if(_context.User != null)
            {
                bool status = false;
                if (!string.IsNullOrWhiteSpace(registerDto.Username) &&
                    !string.IsNullOrWhiteSpace(registerDto.Password) &&
                    !string.IsNullOrWhiteSpace(registerDto.Email) &&
                    !string.IsNullOrWhiteSpace(registerDto.Address) &&
                    !string.IsNullOrWhiteSpace(registerDto.Phone) &&
                    !string.IsNullOrWhiteSpace(registerDto.National_Id)) 
                {
                    User register = new User
                    {
                        Email = registerDto.Email,
                        Username = registerDto.Username,
                        Password  = registerDto.Password,
                        BirthDate = registerDto.BirthDate,
                        Address = registerDto.Address,
                        Phone = registerDto.Phone,
                        National_Id = registerDto.National_Id
                    };
                    _context.User.Add(register);
                    _context.SaveChanges();
                    status = true;
                    return status;
                }
                else
                {
                    return status;
                }
            }
            return false ;
        }
    }
}
