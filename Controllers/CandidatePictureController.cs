using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatePictureController : Controller
    {
        private readonly ICandidatePictureRepository repository;

        public CandidatePictureController(ICandidatePictureRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("SaveProfilePicture")]
        public async Task<IActionResult> SaveProfilePicture([FromForm] CandidatePictureRequest pictureRequest)
        {
            try
            {
                var response = await repository.SaveProfilePicture(pictureRequest);
                return Ok(response);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error :" + ex.Message);
            }
        }
    }
}
