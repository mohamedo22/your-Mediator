using System.ComponentModel.DataAnnotations;

namespace test.Dto
{
    public class ContactUsDto
    {
        public int RequestId { get; set; }  
        public int UserId { get; set; }
        public string UserEmail{ get; set; }
        public string UserPhone{ get; set; }
        public int FlatCodeId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
    public class ContactUsPostDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FlatCodeId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Time { get; set; }
    }
}
