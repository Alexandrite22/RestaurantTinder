using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly string connectionString;

        private IPartyDao PartyDao { get; set; }
        PartyController(string dbConnectionString)
        {
            PartyDao = new PartySqlDao(dbConnectionString);
        }
        // GET api/<PartyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // TODO: Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            return "value";
        }

        // POST api/<PartyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
           // TODO: Call "CreatyParty" in partySqlDAO
        }

        // PUT api/<PartyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO: Call "UpdateParty" in partySqlDAO
        }

        // DELETE api/<PartyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO: Call "DeleteParty" in partySqlDAO
        }
    }
}
