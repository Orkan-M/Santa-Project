using Microsoft.AspNetCore.Mvc;
using Santa_Project.Models;
using Santa_Project.Data.Country;

namespace Santa_Project.Controllers.Country
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IJsonCountryRepository _countryRepository;
        public CountryController(IJsonCountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<CountryModel>> GetCountry(string name)
        {
            var country = _countryRepository.GetCountryByName(name);
            return Ok(country);
        }

        [HttpPost]
        public IActionResult NewCountry(CountryModel newCountry)
        {
            var country = _countryRepository.AddCountry(newCountry);
            return Ok(country);
        }

        [HttpDelete]
        [Route("{name}")]
        public async Task<ActionResult<CountryModel>> RemoveCountry(string name)
        { 
            _countryRepository.DeleteByName(name);
            return Ok();
        }

        [HttpGet]
        [Route("GetPayload/{name}")]
        public async Task<ActionResult<CountryModel>> GetCountryPayload(string name)
        {
            var countryResults = _countryRepository.GetCountryPayload(name);
            
            //"Payload of the country," + name + ", is: " + countryResults
            return Ok(countryResults);
        }

    }
}