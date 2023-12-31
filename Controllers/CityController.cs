using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityRepository repository;

        public CityController(ICityRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var response = repository.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error : " + ex.Message);
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
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error : " + ex.Message);
            }
        }

        [ActionName("Create")]
        [HttpPost]
        public IActionResult Create(CityMasterRequest request)
        {
            try
            {
                var response = repository.Create(request);

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

        [ActionName("Delete")]
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var response = repository.Delete(id);

                return Ok(response);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error : " + ex.Message);
            }
        }

        [ActionName("Update")]
        [HttpPut]
        public IActionResult Update(CityMasterRequest request)
        {
            try
            {
                var response = repository.Update(request);

                return Ok(response);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "internal server error : " + ex.Message);
            }
        }

    }
}
