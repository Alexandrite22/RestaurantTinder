using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using RestSharp;
using Capstone.Services;
using System.Text.RegularExpressions;
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
        private IGuestDao GuestDao = new GuestSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private IRestaurantDao RestaurantDao = new RestaurantSqlDao("Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;");
        private Businesses tempList = new Businesses();
        private YelpApiService yelpService = new YelpApiService();


        // GET: api/<TinderController>
        [HttpGet("restaurant/{id}")]
        public Business GetYelpApiResults(string id)
        {
            if (Regex.IsMatch(id, @"^\d+$"))//if string is numbers
            {//Get the yelp api_id for the restaurant and get that specific yelp api result and return it
                Restaurant dbRestaurant = RestaurantDao.GetRestaurant(int.Parse(id));
                return yelpService.GetThisBusinessFromYelp(dbRestaurant.ApiId).Result;
            }//else use the ID as if its a normal ID
            var output = yelpService.GetThisBusinessFromYelp(id).Result;
            return output;
        }


        // POST /<TinderController>/like
        [HttpPost("party/{party}/rsvp/{name}")]
        public IActionResult PostRsvp(string name, int party)
        {//return party with updated new party_id as an IActionResult
            return Created("", GuestDao.CreateGuest(name, party));
        }
        // POST /<TinderController>/like
        [HttpPost("rsvp/{name}/")]
        public void PostRsvpWithVotes([FromBody] Dictionary<Restaurant, bool> likes, string name)
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
            GuestDao.DeleteGuest(guestId);
        }
    }
}
