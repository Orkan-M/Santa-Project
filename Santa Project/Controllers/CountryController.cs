using Microsoft.AspNetCore.Mvc;
using Santa_Project.Models;

namespace Santa_Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private static List<CountryModel> _country = new List<CountryModel>
            {
                new CountryModel
                {
                    Id = "1",
                    
                    

                }
            }

        [HttpGet()]
        public async Task<ActionResult<List<CountryModel>>> GetAllCountries()
        {
            return Ok()
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult<CountryModel> RemoveCountry(string Id) {
            return Ok();
        }
           
    }
}