using System.ComponentModel.DataAnnotations;

namespace test.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Can't be Empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Can't be Empty")]
        public string Password { get; set; }
    }

        public class UsersDto
      {
        public int Id { get; set; }
        public string Username { get; set; }
        public string National_Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        }

}
