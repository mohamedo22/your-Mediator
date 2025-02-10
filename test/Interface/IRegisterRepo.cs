using test.Dto;

namespace test.Interface
{
    public interface IRegisterRepo
    {
        bool ForgetPassword(ForgetDto forgetDto);
        bool SignUp(RegisterDto registerDto);
        bool Login(LoginDto registerDto);
        bool EditProfile(EditProfileDto editProfileDto);
    }
}
