using test.Configuration;
using test.Dto;
using test.Interface;
using test.Model;

namespace test.Repos
{
    public class ContactRepo : IContact
    {
        private readonly AppDbContext _context;

        public ContactRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<ContactUsDto> GetAllRequests()
        { 
            List<ContactUsDto> contactUs = new List<ContactUsDto>();    
            foreach(var request in _context.ContactUs)
            {
                var user = _context.User.Find(request.UserId);
                ContactUsDto contactUsDto = new ContactUsDto();
                contactUsDto.FlatCodeId = request.FlatCodeId;   
                contactUsDto.UserId = request.UserId;
                contactUsDto.UserPhone = user.Phone;
                contactUsDto.UserEmail = user.Email;
                contactUsDto.RequestId = request.RequestId;
                contactUsDto.Date  = request.Date;
                contactUsDto.Time = request.Time;
                contactUs.Add(contactUsDto);
            }
            return contactUs;
        }

        public bool PostRequest(ContactUsPostDto contactUsDto)
        {
             bool status = false;
            if (!string.IsNullOrWhiteSpace(contactUsDto.Time) )
            {
                status = true;
                ContactUs contactUs = new ContactUs();
                contactUs.FlatCodeId = contactUsDto.FlatCodeId;
                contactUs.UserId = contactUsDto.UserId;
                contactUs.Time = contactUsDto.Time;
                contactUs.Date = contactUsDto.Date;
                _context.ContactUs.Add(contactUs);
                _context.SaveChanges();
                return status;
            }
                return false;

        }
        public void DeleteRequest(int id)
        {
            var Request = _context.ContactUs.FirstOrDefault(x=> x.RequestId == id);
            if (Request != null)
            {
                _context.ContactUs.Remove(Request);
                _context.SaveChanges();
            }
        }
    }
}
