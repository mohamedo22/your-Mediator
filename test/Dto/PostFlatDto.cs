using System.ComponentModel.DataAnnotations;

namespace test.Dto
{
    public class PostFlatDto
    {
        [Required]
        public int FlatPrice { get; set; }
        [Required]
        public int FlatBathrooms { get; set; }
        [Required]
        public int FlatBedrooms { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        [Required, MaxLength(1500)]
        public string FlatDetails { get; set; }
        [Required, MaxLength(1500)]
        public string FlatAddress { get; set; }
        [Required, MaxLength(50)]
        public string FlatGovernorate { get; set; }
        [Required, MaxLength(50)]
        public string FlatCity { get; set; }
        public List<IFormFile> FlatImages { get; set; }
        public List<IFormFile> FlatDocs { get; set; }
    }
}
