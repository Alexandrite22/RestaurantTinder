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
                IList<Guest> guests = GuestsDao.GetGuests(party.PartyId);
                //make partyviewmodel from values above. 
                // A viewModel is the model of data returned to the view
                PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, restaurants);//
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
 
            //Here we Call "GetParty" in partySqlDAO, "GetRestaurants" from restaurantDAO, "GetGuests" from guestsDAO
            Party party = PartyDao.GetParty(partyId);

            IList<Guest> guests = GuestsDao.GetGuests(partyId);
            //make partyviewmodel from values above. 
            // A viewModel is the model of data returned to the view
            PartyViewModel partyGuestsAndRestaurants = new PartyViewModel(party, guests, restaurants);//
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
            Businesses yelpBusinessList = yelpApiService.GetRestaurantsFromYelpByLocation(createdParty.Location).Result;
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (Business yelpBusiness in yelpBusinessList.BusinessesBusinesses)
            {
                Restaurant restaurant = new Restaurant()
                {
                    PartyId = createdParty.PartyId,
                    Name = yelpBusiness.Name,
                    ApiId = yelpBusiness.Id,
                    YelpLink = yelpBusiness.Url,
                    ImageLink = yelpBusiness.ImageUrl,
                    review_count = yelpBusiness.ReviewCount,
                    rating = yelpBusiness.Rating,
                    longitude = yelpBusiness.Coordinates.Longitude,
                    latitude = yelpBusiness.Coordinates.Latitude,
                    address1 = yelpBusiness.Location.Address1,
                    address2 = yelpBusiness.Location.Address2,
                    //address3 = yelpBusiness.Location.Address3,
                    city = yelpBusiness.Location.City,
                    state = yelpBusiness.Location.State,
                    zip = yelpBusiness.Location.ZipCode,
                    country = yelpBusiness.Location.Country,
                    display_address1 = yelpBusiness.Location.DisplayAddress[0],
                    display_address2 = yelpBusiness.Location.DisplayAddress[1]
                };
                restaurants.Add(restaurant);
            }
            foreach (Restaurant restaurant in restaurants)
            {
                restaurant.RestaurantId = RestaurantsDao.Create(restaurant);
            }
            return new PartyViewModel(createdParty, new List<Guest>(), restaurants);
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

    }
}
