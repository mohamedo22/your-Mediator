using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Dto;
using test.Interface;
using test.Model;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatRepo _repo;

        public FlatController(IFlatRepo flatRepo)
        {
            this._repo = flatRepo;
        }
        [HttpPost("FlatPost")]
        public IActionResult FlatPost([FromForm] PostFlatDto postFlatDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
          else 
            {
                bool status = _repo.PostFlat(postFlatDto);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Flat Request Sent Successfully!"
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
        public IActionResult GetFlat()
        {
            var flats = _repo.GetFlat();
            if (flats != null)
            {
                return Ok(new
                {
                    flats,
                    message = "Flat Fetched"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "No Flats Fetched"
                });
            }

        }
        [HttpDelete("{FlatId}")]
        public IActionResult RemoveFlat(int FlatId)
        {
            bool status = _repo.RemoveFlat(FlatId);
            if (status)
            {
                return Ok(new
                {
                    status,
                    message = "Flat Deleted Successfully!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    status,
                    message = "Invalid Operation "
                });
            }
        }
        [HttpPatch("FlatEdit")]
        public IActionResult FlatEdit([FromForm] PostFlatDto postFlatDto, int id)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            else{
                bool status = _repo.EditFlat(postFlatDto, id);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Flat Data Modified Successfully!"
                    });
                }
                return BadRequest(new
                {
                    status,
                    message = "Invalid Data Entered"
                });
            }
        }
        [HttpPatch("FlatStatusEdit")]
        public IActionResult FlatStatusEdit(string Status, int id)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }
            else
            {
                bool status = _repo.EditFlat(Status, id);
                if (status)
                {
                    return Ok(new
                    {
                        status,
                        message = "Flat Status has been Modified Successfully!"
                    });
                }
                return BadRequest(new
                {
                    status,
                    message = "Invalid Data Entered"
                });
            }
        }
    }

}
  

