using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class RestaurantSqlDao : IRestaurantDao
    {
        private readonly string connectionString;

        public RestaurantSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        //Create a method that takes in a Restaurant object and adds it to the database
        public void Create(Restaurant restaurant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO restaurant (party_id, api_id, yelp_link, image_link) VALUES (@party_id, @api_id, @yelp_link, @image_link)", connection);
                command.Parameters.AddWithValue("@party_id", restaurant.PartyId);
                command.Parameters.AddWithValue("@api_id", restaurant.ApiId);
                command.Parameters.AddWithValue("@yelp_link", restaurant.YelpLink);
                command.Parameters.AddWithValue("@image_link", restaurant.ImageLink);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// Get a restaurant based on a restaurantId
        /// takes in restaurantId int and returns a restaurant object
        /// </summary>
        /// <param name="restaurantId"></param>
        /// <returns></returns>
        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection to db
                conn.Open();

                // Create new sql command to select restaurant where restaurantId and restaurant_id match
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant WHERE restaurant_id = @restaurant_id", conn);

                // Add restaurantId to sql command
                cmd.Parameters.AddWithValue("@restaurant_id", restaurantId);

                // Run query and save values to reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) //while there are results to read
                {
                    //the restaurant we return is the restaurant we read
                    restaurant = CreateRestaurantFromReader(reader);
                }
            }
            return restaurant;
        }

        /// <summary>
        /// Get restaurant choices based on a partyId
        /// takes in partyId int, returns IList<Restaurants>
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        public IList<Restaurant> GetRestaurants(int partyId)
        {
            IList<Restaurant> restaurants = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection to db
                conn.Open();

                // Create new sql command to select all restaurants where partyId and party_id match
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant WHERE party_id = @party_id", conn);

                // Add partyId to sql command
                cmd.Parameters.AddWithValue("@party_id", partyId);

                // Run query and save values to reader
                SqlDataReader reader = cmd.ExecuteReader();

                // Create new list of restaurants
                restaurants = new List<Restaurant>();

                while (reader.Read()) //while there are results to read
                {
                    // Add restaurant to list of restaurants
                    restaurants.Add(CreateRestaurantFromReader(reader));
                }
            }
            return restaurants;
        }

        private Restaurant CreateRestaurantFromReader(SqlDataReader reader)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.RestaurantId = Convert.ToInt32(reader["restaurant_id"]);
            restaurant.PartyId = Convert.ToInt32(reader["party_id"]);
            restaurant.Name = Convert.ToString(reader["Name"]);
            restaurant.YelpLink = Convert.ToString(reader["yelp_link"]);
            restaurant.ImageLink = Convert.ToString(reader["image_link"]);
            restaurant.ApiId = Convert.ToString(reader["api_id"]);
            return restaurant;
        }


    }
}
