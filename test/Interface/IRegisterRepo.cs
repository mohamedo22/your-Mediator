using test.Dto;

namespace test.Interface
{
    public interface IRegisterRepo
    {
        bool ForgetPassword(ForgetDto forgetDto);
        bool SignUp(UserDto registerDto);
        UsersDto Login(LoginDto registerDto);
        bool EditProfile(EditProfileDto editProfileDto);
    }
}
