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
        private Businesses tempList = new Businesses();
        private YelpApiService yelpService = new YelpApiService();


        //// GET: api/<TinderController>
        //[HttpGet]
        //public List<RestaurantViewModel> Get()
        //{
        //    YelpApiService yelpService = new YelpApiService();
        //    return yelpService.CreatePracticeRestaurants();
        //}

        //// GET /<TinderController>/5
        ///// Get the restaurants for a particular party
        ///// takes in partyId as an int in endpoint path
        //[HttpGet("{partyId}")]
        //public List<RestaurantViewModel> GetRestaurants(int partyId)
        //{
        //    YelpApiService yelpService = new YelpApiService();
        //    return yelpService.CreatePracticeRestaurants();


        //}
        // GET: api/<TinderController>
        [HttpGet("restaurant/{id}")]
        public async Task<Business> GetYelpApiResults(string id)
        {
            // takes in a restaurant api address as a string, for example
            // "https://www.yelp.com/biz/marmar-s-pizza-cleveland-heights
            // ?adjust_creative=lRzblQl-ehLXFsgKraH69g&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=lRzblQl-ehLXFsgKraH69g"


            //curl --request GET \
            //--url 'https://api.yelp.com/v3/businesses/search?sort_by=best_match&limit=20' \
            //--header 'Authorization: lRzblQl-ehLXFsgKraH69g' \
            //--header 'accept: application/json'

            Business YelpRestaurantData = await yelpService.GetThisRestaurantFromYelp(id);


            throw new Exception();


        }


        // POST /<TinderController>/like
        [HttpPost]
        public void PostLikeDislike([FromBody] List<LikeDislike> LikeDislike)
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
