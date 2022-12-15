using Capstone.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Capstone;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Capstone.Services
{
    public class YelpApiService
    {
        private string BearerToken =
            //"lHUWILnhPqMKo98Qwx5o8DYbTZld_XTZnUXrwUVleQF3sYTI94PffLlxqbVkA--UcUcVP5aI1UN8kwKA4mdXF626Grde4LiYZXbdsLthNeaM60wsv1nIcBZCLrCQY3Yx";
            "AD-ZZsrDzfM08bxsnNrt_Rv8ah_MKR6MxDtZ9uG23axMJ2p4-UAFa8MNLCmtDWpNzj-QvT_NwsC8rUDso2PzTDRykXhbVcmCpYBgD30fDVX8XItccxOAGnrbkRGaY3Yx";
        //private yelpApiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");
        public string yelpApiBaseUrl { get; set; }
        public YelpApiService()
        {
            yelpApiBaseUrl = "https://api.yelp.com/v3";

        }

        public async Task<Business> GetThisBusinessFromYelp(string apiId) //Task<RestaurantViewModel> is a promise that you will return a restaurantViewModel. 
        {
            Business restaurant = new Business();
            string baseUrl = "https://api.yelp.com/v3/businesses/";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
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
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);
                using (var response = await httpClient.GetAsync("https://api.yelp.com/v3/businesses/search?sort_by=rating&limit=20&location=" + location) )
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurants = JsonConvert.DeserializeObject<Businesses>(apiResponse); //Will have errors we will need to handle intake of yelp data and format it to our c# model
                }
            }

            return restaurants;
        }
        public async Task<Businesses> GetTheseRestaurantsFromYelp(IList<Restaurant> restaurants)
        {
            Businesses businesses = new Businesses();
            foreach (Restaurant restaurant in restaurants)
            {
                Business business = await GetThisBusinessFromYelp(restaurant.ApiId);
                businesses.BusinessesBusinesses.Add(business);
            }

            return businesses;

        }
    }
}