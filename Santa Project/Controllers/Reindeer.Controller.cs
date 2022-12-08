using Microsoft.AspNetCore.Mvc;
using Santa_Project.Models;

namespace Santa_Project.Controllers
{
    public class Reindeer : Controller
    {
        private static List<ReindeerModel> _reindeer = new List<ReindeerModel>
        {
            
        }

        [HttpDelete]
        [Route("{Name}")]
        public async Task<ActionResult<> 

    }
}
