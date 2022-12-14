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


        // GET: api/<TinderController>
        [HttpGet("restaurant/{id}")]
        public Business GetYelpApiResults(string id)
        {

            Business YelpRestaurantData = yelpService.GetThisBusinessFromYelp(id).Result;

            return YelpRestaurantData;
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
