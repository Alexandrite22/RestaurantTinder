using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Capstone;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Capstone.Services
{
    public class YelpApiService
    {
        //private yelpApiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        public string yelpApiBaseUrl { get; set; }
        public YelpApiService()
        {
            yelpApiBaseUrl = "https://api.yelp.com/v3";

        }

        public async Task<Business> GetThisRestaurantFromYelp(string apiId) //Task<RestaurantViewModel> is a promise that you will return a restaurantViewModel. 
        {
            Business restaurant = new Business();
            string baseUrl = "https://api.yelp.com/v3/businesses/";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(baseUrl + apiId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurant = JsonConvert.DeserializeObject<Business>(apiResponse); //Will have errors we will need to handle intake of yelp data and format it to our c# model
                }
            }
            return restaurant;
        }
        public async Task<Businesses> GetRestaurantsFromYelpByLocation(string location) //Task<RestaurantViewModel> is a promise that you will return a restaurantViewModel. 
        {
            Businesses restaurants = new Businesses();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=" + location) )
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurants = JsonConvert.DeserializeObject<Businesses>(apiResponse); //Will have errors we will need to handle intake of yelp data and format it to our c# model
                }
            }

            return restaurants;
        }
    }
}