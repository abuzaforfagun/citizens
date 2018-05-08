using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using web_api.Models.Citizen;
using web_api.Presistance;

namespace web_api.Controllers
{
    [Route("api/v1/citizens")]
    // [EnableCors("AllowAll")]
    // [EnableCors("CorsPolicy")]
    public class CitizensController : Controller
    {
        private CitizenRepository repository;
        private readonly IMapper mapper;
        public CitizensController(IConfiguration configuration, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = new CitizenRepository(configuration);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]CitizenPresistance citizenPresistance)
        {
            // Citizen citizen = this.mapper.Map<CitizenPresistance, Citizen>(citizenPresistance);
            var citizen = this.mapper.Map<CitizenPresistance, Citizen>(citizenPresistance);
            citizen = this.repository.Add(citizen);
            if (citizen == null)
            {
                return BadRequest();
            }
            return Ok(citizen);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
