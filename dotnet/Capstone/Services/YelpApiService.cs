using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
namespace Capstone.Services
{
    public class YelpApiService
    {
        public List<RestaurantViewModel> CreatePracticeRestaurants()
        {
            // create an empty list of restaurants
            List<RestaurantViewModel> listOfRestaurants = new List<RestaurantViewModel>();
            // loop 20 times to make 20 restaurants
            for (int i = 0; i < 10; i++)
            {
                // add a restaurant to the list
                listOfRestaurants.Add(CreatePracticeRestaurantViewModel());
                listOfRestaurants.Add(CreatePracticeRestaurantViewModel2());
            }
            return listOfRestaurants;
        }
        public RestaurantViewModel CreatePracticeRestaurantViewModel()
        {
            // Select a random int from 1 to 1000 and set it as id
            int id = new Random().Next(1, 1000);
            // return a new restaurant view model
            return new RestaurantViewModel(
              id,
              1,
              "MarMar’s Pizza",
              "1975 Lee Rd" + ", " + "Cleveland Heights" + ", " + "OH" + ", " + "44118",
              // create a list of categories for the restaurant
              new List<string>() { "Pizza", "Italian", "Wings", "Delivery" },
              "216-316-3355",

              //create list of menu items
              new List<string>() { "Pizza", "Wings", "Salad", "Breadsticks" },
              //create list of hours
              new List<string>() { "Monday: 11:00 am - 10:00 pm", "Tuesday: 11:00 am - 10:00 pm", "Wednesday: 11:00 am - 10:00 pm", "Thursday: 11:00 am - 10:00 pm", "Friday: 11:00 am - 10:00 pm", "Saturday: 11:00 am - 10:00 pm", "Sunday: 11:00 am - 10:00 pm" },
              "https://www.yelp.com/biz/marmar-s-pizza-cleveland-heights?adjust_creative=lRzblQl-ehLXFsgKraH69g&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=lRzblQl-ehLXFsgKraH69g",
              "https://s3-media1.fl.yelpcdn.com/bphoto/pv2QY8bNbcP0jwdTxwkxAA/o.jpg");
        }
        public RestaurantViewModel CreatePracticeRestaurantViewModel2()
        {
            // Select a random int from 1 to 1000 and set it as id
            int id = new Random().Next(1, 1000);
            // return a new restaurant view model
            return new RestaurantViewModel(
              id,
              1,
              "RAmRam’s Pizza and Pasta",
              "999 Lee Rd" + ", " + "Cleveland Heights" + ", " + "OH" + ", " + "44118",
              // create a list of categories for the restaurant
              new List<string>() { "Pizza", "Italian", "Wings", "Delivery" },
              "123-333-3333",

              //create list of menu items
              new List<string>() { "Pizza", "Wings", "Salad", "Breadsticks" },
              //create list of hours
              new List<string>() { "Monday: 11:00 am - 10:00 pm", "Tuesday: 11:00 am - 10:00 pm", "Wednesday: 11:00 am - 10:00 pm", "Thursday: 11:00 am - 10:00 pm", "Friday: 11:00 am - 10:00 pm", "Saturday: 11:00 am - 10:00 pm", "Sunday: 11:00 am - 10:00 pm" },
              "https://www.yelp.com/biz/marmar-s-pizza-cleveland-heights?adjust_creative=lRzblQl-ehLXFsgKraH69g&utm_campaign=yelp_api_v3&utm_medium=api_v3_business_search&utm_source=lRzblQl-ehLXFsgKraH69g",
              "https://i.pinimg.com/474x/a6/22/ba/a622ba97812a85d42d7a37000dc89062--funny-things-funny-stuff.jpg");
        }

        public RestaurantViewModel GetThisRestaurantFromYelp()
        {
            throw new NotImplementedException();
        }
    }
}