using MatrimonyWebApi.Repositories;
using MatrimonyWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MatrimonyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository repository;

        public CountryController(ICountryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await repository.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) 
        {
            try
            {
                var response = repository.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CountryRequest request) 
        {
            try
            {
                var response = repository.Create(request);

                return Ok(response);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var response = repository.Delete(id);

                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal server error :" + ex.Message);
            }            
        }

        [HttpPut]
        public IActionResult Update(CountryRequest request) 
        {
            try
            {
                var response = repository.Update(request);

                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("Invalid request id");
            }
            catch (Exception ex)
            {

                return StatusCode(500, "internal server error :" + ex.Message);
            }
        }
    }
}
