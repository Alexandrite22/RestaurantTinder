using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TinderController : ControllerBase
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;";
        // TODO: add partyDao, guestsDAO, restaurantDAO
        private IPartyDao PartyDao = new PartySqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IGuestDao GuestsDao = new GuestSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IRestaurantDao RestaurantsDao = new RestaurantSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private List<Restaurant> tempList = new List<Restaurant>();



        // GET: api/<TinderController>
        [HttpGet]
        public List<RestaurantViewModel> Get()
        {
            YelpApiService yelpService = new YelpApiService();
            return yelpService.CreatePracticeRestaurants();
        }

        // GET /<TinderController>/5
        /// Get the restaurants for a particular party
        /// takes in partyId as an int in endpoint path
        [HttpGet("{partyId}")]
        public List<RestaurantViewModel> GetRestaurants(int partyId)
        {
            YelpApiService yelpService = new YelpApiService();
            return yelpService.CreatePracticeRestaurants();

           
        }



        // POST /<TinderController>/like
        [HttpPost]
        public void Post([FromBody] LikeDislike LikeDislike)
        {
            throw new NotImplementedException();
        }

        // PUT /<TinderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // Deletes guest based on their guest Id
        [HttpDelete("guest/{guestId}")]
        public void Delete(int guestId)
        {
            GuestsDao.DeleteGuest(guestId);
        }


                 

    }
}
