using System;
using System.Collections.Generic;
using Capstone.Models;
using Capstone.Services;
namespace Capstone.Services
{
    public class TypeConverterHelper
    {
        //write a method that takes in a Businesses object and creates a restaurant object from it
        public static List<Restaurant> CreateRestaurant(Businesses businesses, int partyId)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (Business business in businesses.BusinessesBusinesses)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = business.Name;
                restaurant.PartyId = partyId;
                restaurant.ApiId = business.Id;
                restaurant.ImageLink = business.ImageUrl;
                restaurant.YelpLink = business.Url;
                restaurants.Add(restaurant);
            }
            return restaurants;
        }

    }
}
