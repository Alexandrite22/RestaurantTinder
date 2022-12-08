using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using RestSharp;
using Capstone.Services;
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
            GuestsDao = new GuestSqlDao(dbConnectionString);
            RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        }
        // GET /<PartyController>/5
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
        [HttpGet("restaurants/{partyId}")]
        public List<RestaurantViewModel> GetRestaurants(int partyId)
        {
           YelpApiService yelpService = new YelpApiService();
            return yelpService.CreatePracticeRestaurants();
        }

        /// POST /<PartyController>
        /// 
        public int Post([FromBody] Party newParty)
        {
            //Use partyDao.CreateParty(newParty) to create a new party, and return the ID of the party

            // newPartyId is the Id of the newly created party
            int newPartyId = PartyDao.CreateParty(newParty).PartyId;
            return newPartyId;
        }

        // PUT /<PartyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Party updatedParty)
        {
            //TODO: Call "UpdateParty" in partySqlDAO
        }

        // DELETE /<PartyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO: Call "DeleteParty" in partySqlDAO
        }


        /// POST /<PartyController>/location
        /// 
        //public IList<Restaurant> Post([FromBody] string zipcode)
        //{
        //    //TODO: CALL YELP API AND GET 25 Restaurants AND DETAILS FROM ZIP CODE
        //    //
        //    var client = new RestClient("https://api.yelp.com/v3/businesses/search?sort_by=best_match&limit=20");
        //    var request = new RestRequest(Method.GET);
        //    request.AddHeader("accept", "application/json");
        //    IRestResponse response = client.Execute(request);

        //    throw new NotImplementedException();
        //}

       
    }
}
