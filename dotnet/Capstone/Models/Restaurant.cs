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
        public string Name { get; set; }
        public string ApiId { get; set; }
        public string YelpLink { get; set;}
    }
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public IList<string> TypeOfRestaurant { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImageUrl { get; set; }

        public string ApiId { get; set; }
        public bool IsClosed { get; set; }
        public double Rating { get; set; }
        public string YelpLink { get; set; }
        public RestaurantViewModel(Restaurant restaurant)
        {
            RestaurantId = restaurant.RestaurantId;
            PartyId = restaurant.PartyId;
            Name = "name";
            TypeOfRestaurant = new List<string>() { "TEST", "Restaurant" }; ;
            Address = "Address";
            PhoneNumber = "phoneNumber";
            ApiId = restaurant.ApiId;
            ImageUrl = "imageUrl";
            IsClosed = false;

        }
        public RestaurantViewModel(Restaurant dbRestaurant, RestaurantYelpModel restaurantYelpModel)
        {
            {
                PartyId = dbRestaurant.PartyId;
                RestaurantId = dbRestaurant.RestaurantId;
                Name = restaurantYelpModel.name;
                TypeOfRestaurant = restaurantYelpModel.categories;
                Address = restaurantYelpModel.location.display_address[1] + restaurantYelpModel.location.display_address[2];
                PhoneNumber = restaurantYelpModel.display_phone;
                ApiId = dbRestaurant.ApiId;
                YelpLink = dbRestaurant.YelpLink;
                ImageUrl = restaurantYelpModel.image_url;
                IsClosed = restaurantYelpModel.is_closed;
                Rating = restaurantYelpModel.rating;
            }
        }
    }
    public class RestaurantYelpModel
    {
        public string id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public bool is_closed { get; set; }
        public string url { get; set; }
        public int review_count { get; set; }
        public List<string> categories { get; set; }
        public double rating { get; set; }
        public List<string> coordinates { get; set; }
        public List<string> transactions { get; set; }
        public Location location { get; set; }
        public string phone { get; set; }
        public string display_phone { get; set; }
        public float distance { get; set; }
    }
}
