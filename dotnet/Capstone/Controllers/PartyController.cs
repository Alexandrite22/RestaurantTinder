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
        private IPartyDao PartyDao = new PartySqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IGuestDao GuestsDao = new GuestSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IRestaurantDao RestaurantsDao = new RestaurantSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");




        //PartyController()
        //{
        //    //PartyDao = new PartySqlDao(dbConnectionString);
        //    //GuestsDao = new GuestSqlDao(dbConnectionString);
        //    //RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        //}
        // GET /<PartyController>/5
        [HttpGet]
        public IList<PartyViewModel> Get()
        {
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            IList<Party> parties = PartyDao.GetParties(1);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            IList<PartyViewModel> partyViewModels = new List<PartyViewModel>();
            foreach (var party in parties)
            {
                PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, new List<Guest>(), new List<Restaurant>());
                partyViewModels.Add(partyGuestsAndRestaurants);
            }
            return partyViewModels;
        }

        //PartyController()
        //{
        //    //PartyDao = new PartySqlDao(dbConnectionString);
        //    //GuestsDao = new GuestSqlDao(dbConnectionString);
        //    //RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        //}
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
        public int Post([FromBody] Party updatedParty)
        {
            //Use partyDao.CreateParty(newParty) to create a new party, and return the ID of the party
            
            // newPartyId is the Id of the newly created party
            Party newParty = new Party();
            newParty.Name = updatedParty.Name;
            newParty.Date = updatedParty.Date;
            newParty.Owner = updatedParty.Owner;
            newParty.Location = updatedParty.Location;
            newParty.Description = updatedParty.Description;
            newParty.InviteLink = updatedParty.InviteLink;

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
