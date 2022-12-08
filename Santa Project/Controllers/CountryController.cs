using Microsoft.AspNetCore.Mvc;
using Santa_Project.Models;

namespace Santa_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IJsonCountryRepsoitory _coutryRepository;
        public CountryController(IJsonCountryRepsitory countryRepository)
        {
            _coutryRepository = countryRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountries()
        {
            var country = _
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<CountryModel> RemoveCountry(string Id) {
            return Ok();
        }
           
    }
}