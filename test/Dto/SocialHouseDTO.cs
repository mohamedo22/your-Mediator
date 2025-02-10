using test.Model;

namespace test.Dto
{
    public class SocialHouseDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public string terms { get; set; }
        public List<IFormFile> socialHouseImages { get; set; }
    }
}
