using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class GuestsqlDao
    {
        private readonly string connectionString;

        public GuestsqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        // Get full guest table information based on party ID
        public Guest GetGuest(int partyId)
        {
            Guest guest = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM guest", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    guest = CreateGuestFromReader(reader);
                }

            }
            return guest;
        }

        private Guest CreateGuestFromReader(SqlDataReader reader)
        {
            Guest guest = new Guest();
            guest.GuestId = Convert.ToInt32(reader["guest_id"]);
            guest.Name = Convert.ToInt32(reader["name"]);
            guest.PartyId = Convert.ToInt32(reader["party_id"]);
            return guest;
        }
    }
}
