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
            //GET ALL partiesVIEWMODELS
            //PartyVIEWMODELS HAVE PARTY PROPERTIES AND A BUSINESSES LIST
            //GET BUSINESSES WITH 
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            IList<Party> parties = PartyDao.GetParties(1);
            //DEAR LORD IS THIS INNEFICIENT WTF
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            IList<PartyViewModel> partyViewModels = new List<PartyViewModel>();
            foreach (var party in parties)
            {
                IList<Restaurant> restaurants = RestaurantsDao.GetRestaurants(party.PartyId);
                Task<Businesses> businesses = yelpApiService.GetTheseRestaurantsFromYelp(restaurants);
                IList<Guest> guests = GuestsDao.GetGuests(party.PartyId);
                //make partyviewmodel from values above. 
                // A viewModel is the model of data returned to the view
                PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, businesses.Result);//
                partyViewModels.Add(partyGuestsAndRestaurants);
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

        /// POST /<PartyController>
        //create a jason object for a Party class
        // {

        [HttpPost]
        public PartyViewModel Post([FromBody] Party createdParty)
        {
            //Use partyDao.CreateParty(newParty) to create a new party, and return the ID of the party

            // newPartyId is the Id of the newly created part
            createdParty = PartyDao.CreateParty(createdParty);
            //Make new restaurants
            Task<Businesses> yelpBusinessList = yelpApiService.GetRestaurantsFromYelpByLocation(createdParty.Location);
            List<Restaurant> restaurants = TypeConverterHelper.CreateRestaurant(yelpBusinessList.Result, createdParty.PartyId);
            foreach (Restaurant restaurant in restaurants)
            {
                restaurant.PartyId = createdParty.PartyId;
                RestaurantsDao.Create(restaurant);
            }
            return new PartyViewModel(createdParty, new List<Guest>(), yelpBusinessList.Result);
        }
        [HttpPost("restaurants/{partyId}")]
        public void PostRestaurantFromVueYelpFOrmat([FromBody] Businesses businesses, int partyId)
        {
            foreach (Business business in businesses.BusinessesBusinesses)
            {
                RestaurantsDao.CreateRestaurantFromBusinessAndParty(business, partyId);
            }
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

        [HttpGet("minTest/")]
        public IList<PartyMinModel> GetMinData()
        {
            IList<Party> parties = PartyDao.GetParties(1);
            IList<PartyMinModel> partyMinModels = new List<PartyMinModel>();
            foreach (var party in parties)
            {
                partyMinModels.Add(new PartyMinModel(party.PartyId));
            }
            partyMinModels = partyMinModels.Reverse().ToList();
            return partyMinModels;
        }
        [HttpGet("minTest/{partyId}")]
        public PartyMinModel GetMinDataFOrParty(int partyId)
        {
            return new PartyMinModel(partyId);
        }
    }
}
