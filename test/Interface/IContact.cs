using test.Dto;

namespace test.Interface
{
    public interface IContact
    {
        public bool PostRequest(ContactUsPostDto contactUsDto);
        public void DeleteRequest(int id);
        public List<ContactUsDto> GetAllRequests();
    }
}
