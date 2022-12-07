using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class RestaurantSqlDao
    {
        private readonly string connectionString;

        public RestaurantSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        // Get a restaurant based on restaurant id...
        public Restaurant GetRestaurant(int restaurantId)
        {
            Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    restaurant = CreateRestaurantFromReader(reader);
                }

            }
            return restaurant;
        }

        // Get restaurant choices based on party id... 
        public Restaurant GetRestaurants (int partyId)
        {
            Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    restaurant = CreateRestaurantFromReader(reader);
                }
     
            }
            return restaurant;
        }

        private Restaurant CreateRestaurantFromReader(SqlDataReader reader)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.RestaurantId = Convert.ToInt32(reader["restaurant_id"]);
            restaurant.PartyId = Convert.ToInt32(reader["party_id"]);
            restaurant.Name = Convert.ToString(reader["name"]);
            restaurant.ApiAddress = Convert.ToString(reader["Api_address"]);
            return restaurant;
        }

    }
}
