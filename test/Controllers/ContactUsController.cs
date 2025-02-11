using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Dto;
using test.Interface;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContact contact;

        public ContactUsController(IContact contact)
        {
            this.contact = contact;
        }

        [HttpDelete("{RequestId}")]
        public IActionResult RemoveRequest(int RequestId)
        {  
              contact.DeleteRequest(RequestId);
                return Ok(new
                {
                    message = "Request " + RequestId + " Deleted Successfully!" 
                });
        }
        [HttpPost("RequestPost")]
        public IActionResult RequestPost(ContactUsPostDto postrequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            else
            {
               bool status =  contact.PostRequest(postrequestDto);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Request Sent Successfully!"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        status,
                        message = "Invalid Data Entered"
                    });
                }
            }
        }
        [HttpGet]
        public IActionResult GetAllRequest()
        {
            var Requests = contact.GetAllRequests();
            if (Requests != null)
            {
                    return Ok(new
                    {
                        Requests,
                        message = Request.ContentLength + " Requests Fetched"
                    });
            }
            else
            {
                return BadRequest(new
                {
                    Requests,
                    message = "No Requests Fetched"
                });
            }

        }

    }
}
