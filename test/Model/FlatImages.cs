namespace test.Model
{
    public class FlatImages
    {
        public int FlatImagesId { get; set; }
        public int FlatCodeId { get; set; }
        public Flat Flat { get; set; }
        public byte[] Flatimage { get; set; }
    }
}
