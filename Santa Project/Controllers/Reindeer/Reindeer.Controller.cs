using Microsoft.AspNetCore.Mvc;
using Santa_Project.Data.Country;
using Santa_Project.Models;

namespace Santa_Project.Controllers.Reindeer
{
    //[Route("[controller]")]
    //[ApiController]
    //public class ReindeerController : ControllerBase
    //{
    //    private readonly IJsonCountryRepository _reindeerRepository;
    //    public ReindeerController(IJsonCountryRepository reindeerRepository)
    //    {
    //        _reindeerRepository = reindeerRepository;
    //    }

    //    [HttpGet("{name}")]
    //    public async Task<ActionResult<ReindeerModel>> GetReindeer(string name)
    //    {
    //        var Reindeer = _reindeerRepository.GetReindeerById(name);
    //        return Ok(Reindeer);
    //    }

    //    //[HttpDelete]
    //    //[Route("{Id}")]
    //    //public async Task<ActionResult<ReindeerModel> RemoveReindeer(string Id) {
    //     //   return Ok();
    //}

}
