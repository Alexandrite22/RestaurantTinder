using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public string ApiAddress { get; set; }
    }
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public IList<string> TypeOfRestaurant { get; set; }
        public IList<string> Menu { get; set; }
        public string Address { get; set; }
        public IList<string> Hours { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }

        public string ApiAddress { get; set; }
        public RestaurantViewModel(
            int id, 
            int partyId, 
            string name, 
            string address,
            List<string> typeOfRestaurant,
            string phoneNumber, 
            List<string> menu, 
            List<string> hours,  
            string apiAddress, 
            string imageUrl)
        {
            RestaurantId = id;
            PartyId = partyId;
            Name = name;
            TypeOfRestaurant = typeOfRestaurant;
            Address = address;
            Menu = menu;
            Hours = hours;
            PhoneNumber = phoneNumber;
            ApiAddress = apiAddress;
            ImageUrl = imageUrl;
        }
    }
}
