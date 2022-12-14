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
        //Create a method that takes in a string called name and an int called partyId and creates a new guest database record

        public Guest CreateGuest(string name, int partyId)
        {
            if(DoesGuestExist(name, partyId))
            {   //return the existing guest record
                return GetGuest(name, partyId);
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //write a SqlCommand that inserts a new guest into the guest table, and returns its guest_id field
                SqlCommand cmd = new SqlCommand("INSERT INTO guest (name, party_id) VALUES (@name, @party_id); SELECT @@IDENTITY", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@party_id", partyId);
                //return the guest we just created as a guest object
                Guest output = new Guest();
                output.GuestId = Convert.ToInt32(cmd.ExecuteScalar());

                output.Name = name;
                output.PartyId = partyId;
                return output;
            }
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
        //Create a method called GetGuest(string name, int partyId) that returns a guest object based on the name and partyId
        public Guest GetGuest(string name, int partyId)
        {
            Guest guest = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open connection to db
                conn.Open();
                // Create new sql command to select guest where guestId and guest_id match
                SqlCommand cmd = new SqlCommand("SELECT * FROM guest WHERE name = @name AND party_id = @party_id", conn);

                // Add guestId to sql command
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@party_id", partyId);

                // Run query and save values to reader
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) //while there are results to read
                {
                    //the guest we return is the guest we read
                    return CreateGuestFromReader(reader);
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
            guest.Name = Convert.ToString(reader["name"]);
            guest.PartyId = Convert.ToInt32(reader["party_id"]);
            return guest;
        }

        private bool DoesGuestExist(string name, int partyId)
        {
            //find if a guest with a specific name and party ID exists in the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //write a SqlCommand that inserts a new guest into the guest table, and returns its guest_id field
                SqlCommand cmd = new SqlCommand("SELECT * FROM guest WHERE name = @name AND party_id = @party_id", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@party_id", partyId);
                //return the guest we just created as a guest object
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            
            return false;
        }
        
    }
}
