using Microsoft.AspNetCore.Mvc;
using Santa_Project.Data.Reindeer;
using Santa_Project.Models;

namespace Santa_Project.Controllers.Reindeer
{
    [Route("[controller]")]
    [ApiController]
    public class ReindeerController : ControllerBase
    {
        private readonly IReindeerRepository _reindeerrepository;

        public ReindeerController(IReindeerRepository reindeerrepository)
        {
            _reindeerrepository = reindeerrepository;
        }

        [HttpGet("{name}")]
        public IActionResult GetReindeer(string name)
        {
            var reindeer = _reindeerrepository.GetReindeerByName(name);
            return Ok(reindeer);
        }

        [HttpPost]
        [Route("/AddReindeer")]
        public IActionResult AddReindeer(ReindeerModel reindeer)
        {
            var newReindeer = _reindeerrepository.AddReindeer(reindeer);
            return Ok(newReindeer);
        }

        [HttpDelete("{name}")]
        public IActionResult RemoveReindeer(string name)
        {
            _reindeerrepository.RemoveReindeer(name);
            return Ok();
        }

        [HttpPost]
        [Route("/EditReindeer")]
        public IActionResult EditReindeer(ReindeerModel reindeer)
        {
            var editedReindeer = _reindeerrepository.EditReindeer(reindeer);
            return Ok(editedReindeer);
        }


    }
}

