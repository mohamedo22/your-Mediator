using test.Dto;

namespace test.Interface
{
    public interface IFlatRepo
    {
        public bool PostFlat(PostFlatDto postFlatDto);
        public bool EditFlat(PostFlatDto postFlatDto, int id);
        public bool EditFlat(string status, int id);
        public List<GetFlatDto> GetFlat();
        public bool RemoveFlat(int FlatId);
    }
}
 