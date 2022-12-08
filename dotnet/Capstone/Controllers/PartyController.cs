using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly string connectionString;
        // TODO: add partyDao, guestsDAO, restaurantDAO
        private IPartyDao PartyDao { get; set; }
        private IGuestDao GuestsDao { get; set; }
        private IRestaurantDao RestaurantsDao { get; set; }
        PartyController(string dbConnectionString)
        {
            PartyDao = new PartySqlDao(dbConnectionString);
        }
        // GET api/<PartyController>/5
        [HttpGet("{id}")]
        public PartyViewModel Get(int id)
        {
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            Party party = PartyDao.GetParty(id);
            IList<Restaurant> restaurants = RestaurantsDao.GetRestaurants(id);
            IList<Guest> guests = GuestsDao.GetGuests(id);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, restaurants);
            return partyGuestsAndRestaurants;
        }

        // POST api/<PartyController>
        [HttpPost]
        public void Post([FromBody] Party newParty)
        {
            // Set current user as owner value
            var owner = 
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
