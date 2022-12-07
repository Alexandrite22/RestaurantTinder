using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class LikeDislikeSqlDao
    {
        private readonly string connectionString;

        public LikeDislikeSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        // Get full Like-Dislike table based on guest-Id and likeDislike-Id
        public LikeDislike GetLikeDislike(int partyId, int guestId)
        {
            LikeDislike likeDislike = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM liked_disliked", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    likeDislike = CreateLikeDislikeFromReader(reader);
                }

            }
            return likeDislike;
        }

        private LikeDislike CreateLikeDislikeFromReader(SqlDataReader reader)
        {
            LikeDislike likeDislike = new LikeDislike();
            likeDislike.GuestId = Convert.ToInt32(reader["guest_id"]);
            likeDislike.LikeId = Convert.ToInt32(reader["like_disliked_id"]);
            likeDislike.LikeStatus = Convert.ToString(reader["like_or_dislike"]);
            likeDislike.RestaurantId = Convert.ToInt32(reader["restaurant_id"]);
            return likeDislike;
        }
    }
}
