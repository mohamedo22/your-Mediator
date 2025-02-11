using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Model
{
    public class ContactUs
    {
        [Key]
        public int RequestId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int  UserId { get; set; }
        [ForeignKey("FlatCodeId")]
        public Flat Flat { get; set; }
        public int FlatCodeId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

    }
}
