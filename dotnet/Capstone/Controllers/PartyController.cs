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
        private YelpApiService yelpApiService = new YelpApiService();



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
            { //TODO FIX THIS SHIT
                //PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, GuestsDao.GetGuests(party.PartyId));
                //partyViewModels.Add(partyGuestsAndRestaurants);
            }
            // Reverse partyViewModels so that the most recent party is at the top of the list
            partyViewModels = partyViewModels.Reverse().ToList();
            return partyViewModels;
        }

        //PartyController()
        //{
        //    //PartyDao = new PartySqlDao(dbConnectionString);
        //    //GuestsDao = new GuestSqlDao(dbConnectionString);
        //    //RestaurantsDao = new RestaurantSqlDao(dbConnectionString);
        //}
        // GET /<PartyController>/5
        [HttpGet("{partyId}")]
        public PartyViewModel Get(int partyId)
        {
            IList<Restaurant> restaurants = RestaurantsDao.GetRestaurants(partyId);
            Task<Businesses> businesses = yelpApiService.GetTheseRestaurantsFromYelp(restaurants);

            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            Party party = PartyDao.GetParty(partyId);

            IList<Guest> guests = GuestsDao.GetGuests(partyId);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, businesses.Result);//
            return partyGuestsAndRestaurants;
        }



        //[HttpGet("{partyId}/restaurants")]
        //public List<RestaurantViewModel> GetRestaurants(int partyId)
        //{
        //    //TODO CALL THIS FROM PARTYSERVICE IN VUE
        //    YelpApiService yelpService = new YelpApiService();
        //    return yelpService.CreatePracticeRestaurants();
        //}

        /// POST /<PartyController>
        //create a jason object for a Party class
        // {

        [HttpPost]
        public int Post([FromBody] Party createdParty)
        {
            //Use partyDao.CreateParty(newParty) to create a new party, and return the ID of the party
            
            // newPartyId is the Id of the newly created part
            Party newParty = new Party(){
                PartyId = 0,
                Location = createdParty.Location,
                Name = createdParty.Name,
                Date = createdParty.Date,
                // Owner = createdParty.Owner,
                Owner = "1",
                Description = createdParty.Description,
                InviteLink = "https://localhost:44315/tinder/{partyId}"
            };
            int newPartyId = PartyDao.CreateParty(newParty).PartyId;

            //Make new restaurants
            Businesses yelpBusinessList = yelpApiService.GetRestaurantsFromYelpByLocation(newParty.Location).Result;
            List<Restaurant> restaurants = TypeConverterHelper.CreateRestaurant(yelpBusinessList, newPartyId);
            foreach(Restaurant restaurant in restaurants) 
            {
                RestaurantsDao.Create(restaurant);
            }
            return newPartyId;
        }


        // Updates Party based on party ID
        [HttpPut("{updatedPartyId}")]
        public void UpdateParty(int updatedPartyId, [FromBody] Party updatedParty)
        {
            PartyDao.UpdateParty(updatedPartyId, updatedParty);
        }

        // Deletes Party based on party Id
        [HttpDelete("{partyId}")]
        public void Delete(int partyId)
        {
            PartyDao.DeleteParty(partyId);
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
