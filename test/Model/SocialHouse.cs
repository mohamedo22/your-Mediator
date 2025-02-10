namespace test.Model
{
    public class SocialHouse
    {
        public int SocialHouseId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public string terms { get; set; }
        public List<SocialHouseImages> socialHouseImages { get; set; }
    }
}
