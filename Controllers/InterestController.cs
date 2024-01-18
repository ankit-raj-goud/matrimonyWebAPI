using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : Controller
    {
        private readonly IInterestRepository repository;

        public InterestController(IInterestRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetInterests(Guid? senderId = null, Guid? receiverId = null, int? statusId = null)
        {
            try
            {
                var response = repository.GetInterests(senderId,receiverId,statusId);
                return Ok(response);
            }            
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error :" + ex.Message); 
            }
        }

        [ActionName("GetById")]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = repository.GetById(id);
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error : " + ex.Message);
            }
        }

        [ActionName("SendInterest")]
        [HttpPost]
        public IActionResult SendInterest(InterestRequest request)
        {
            try
            {
                var response = repository.SendInterest(request);

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

        [ActionName("Update")]
        [HttpPut]
        public IActionResult Update(InterestRequest request)
        {
            try
            {
                var response = repository.UpdateInterest(request);

                return Ok(response);
            }
            catch (KeyNotFoundException ex)
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
