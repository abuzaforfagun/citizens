using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Presistance;

namespace web_api.Controllers
{
    [Route("api/v1/memorizations")]
    public class MemorizationController : Controller
    {
        private readonly IConfiguration configuration;
        private MemorizationRepository repository;
        public MemorizationController(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;

            this.repository = new MemorizationRepository(configuration);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Memorization memorization)
            {
            memorization = this.repository.Add(memorization);
            if (memorization == null)
            {
                return BadRequest();
            }
            return Ok(memorization);
        }
    }
}