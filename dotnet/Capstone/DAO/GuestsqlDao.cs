using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class GuestSqlDao : IGuestDao
    {
        private readonly string connectionString;

        public GuestSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        // TODO: do we need GetGuest (singular)?
        /// <summary>
        /// Get a guest's name based on their guest ID
        /// </summary>
        /// <param name="guestId"></param>
        /// <returns></returns>
        public Guest GetGuest(int guestId)
        {
            Guest guest = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection to db
                conn.Open();
                // Create new sql command to select guest where guestId and guest_id match
                SqlCommand cmd = new SqlCommand("SELECT * FROM guest WHERE guest_id = @guest_id", conn);

                // Add guestId to sql command
                cmd.Parameters.AddWithValue("@guest_id", guestId);
                
                // Run query and save values to reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) //while there are results to read
                {
                    //the guest we return is the guest we read
                    guest = CreateGuestFromReader(reader);
                }
            }
            return guest;
        }

        /// <summary>
        /// Get full guest table information based on party ID
        /// Takes in partyId and returns list of guests
        /// </summary>
        /// <param name="partyID"></param>
        /// <returns></returns>
        public IList<Guest> GetGuests(int partyID)
        {
            IList<Guest> guests = new List<Guest>();

            //Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection to DB
                conn.Open();
                // Create SQL command that selects all guests where party_id = partyID
                SqlCommand cmd = new SqlCommand("SELECT * FROM guest WHERE party_id = @party_id", conn);
                // Add params
                cmd.Parameters.AddWithValue("@party_id", partyID);

                //Execute SQL command, store results in reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) // While there are more results
                {
                    // Create a new guest object from the reader
                    Guest guest = CreateGuestFromReader(reader);
                    // Add the guest to the list of guests
                    guests.Add(guest);
                }

            }
            // return guests
            return guests;
        }

        // Deletes a guest based on guest ID
        public void DeleteGuest(int guestId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Create new sql command to select guest where guestId and guest_id match
                SqlCommand cmd = new SqlCommand("delete FROM guest WHERE guest_id = @guest_id", conn);
                cmd.Parameters.AddWithValue("@guest_id", guestId);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Create a guest from a row in the db
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
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
