using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PartySqlDao : IPartyDao
    {
        private readonly string connectionString;

        
        public PartySqlDao(string dbConnectionString)// The Constructor for the class.
        {
            connectionString = dbConnectionString; //Dependency injecting the connection string
        }

        /// <summary>
        /// Gets a party using a partyId
        /// takes in a partyId and returns a party
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        public Party GetParty(int partyId)
        {
            Party party = new Party();

            //Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM party where party_id = @party_id", conn);
                cmd.Parameters.AddWithValue("@party_id", partyId);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    party = CreatePartyFromReader(reader);
                }
            }
            return party;
        }


        /// <summary>
        /// Get all parties from a particular user 
        /// Takes in a user id and returns a list of parties
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        // Get all parties based on the user 
        public IList<Party> GetParties(int userId)
        {
            IList<Party> parties = new List<Party>();

            //Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM party where owner = @user_id", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */
                cmd.Parameters.AddWithValue("@user_id", userId);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Party party = CreatePartyFromReader(reader);
                    parties.Add(party);
                }

            }
            return parties;
        }

        // Updates party based on party Id 
        public void UpdateParty(int updatedPartyId, Party updatedParty)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE party SET location = @location, owner = @owner, name_of_party = @nameOfParty, date = @date, description = @description WHERE party_id = @updatedPartyId", conn);
                cmd.Parameters.AddWithValue("@updatedPartyId", updatedPartyId);
                cmd.Parameters.AddWithValue("@location", updatedParty.Location);
                cmd.Parameters.AddWithValue("@owner", updatedParty.Owner);
                cmd.Parameters.AddWithValue("@nameOfParty", updatedParty.Name);
                cmd.Parameters.AddWithValue("@date", updatedParty.Date);
                cmd.Parameters.AddWithValue("@description", updatedParty.Description);

            }
        }

        public void DeleteParty(int partyId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete FROM party WHERE party_id = @partyId", conn);
                cmd.Parameters.AddWithValue("@partyId", partyId);

                cmd.ExecuteNonQuery();
            }
        }



        /// <summary>
        /// Create a party C# object from a sql reader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Party CreatePartyFromReader(SqlDataReader reader)
        {
            Party party = new Party();
            party.PartyId = Convert.ToInt32(reader["party_id"]);
            party.Location = Convert.ToString(reader["location"]);
            party.Owner = Convert.ToString(reader["owner"]);
            party.Name = Convert.ToString(reader["name_of_party"]);
            party.Date = Convert.ToString(reader["date"]);
            party.Description = Convert.ToString(reader["description"]);
            //TODO ADD INVITE LINK TO DB PARTY TABLE AND ADD TO CREATE CODE FOR READING IT HERE
            //party.InviteLink = Convert.ToString(reader["date"]);
            return party;
        }

        /// <summary>
        /// Create a new party in the database from a Party object
        /// Takes in a Party object and returns the new party ID
        /// </summary>
        public Party CreateParty(Party party)
        {
            string link = GetNextPartyLink();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open(); //Open the connection to the DB    

                // Create a new SQL command that inserts a new party into the database and returns the new party_id
                SqlCommand cmd = new SqlCommand("INSERT INTO party (location, owner, name_of_party, description, invite_link) VALUES (@location, @owner, @name_of_party, @description, @invite_link); SELECT @@IDENTITY", conn);
                // Add the parameters to the SQL command
                cmd.Parameters.AddWithValue("@location", party.Location);
                cmd.Parameters.AddWithValue("@owner", 1);
                cmd.Parameters.AddWithValue("@name_of_party", party.Name);
                cmd.Parameters.AddWithValue("@description", party.Description);
                cmd.Parameters.AddWithValue("@invite_link", link);
                //, ((SELECT MAX(party_id) FROM party) +1)

                // Execute the SQL command and get the new party_id.
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                //Convert the new party_id to an int32 and set it to the partyId property of the party object
                return party; //return party with updated new party_id
            }
        }
        private string GetNextPartyLink()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open(); //Open the connection to the DB    

                // Create a new SQL command that inserts a new party into the database and returns the new party_id
                SqlCommand cmd = new SqlCommand("SELECT MAX(party_id) FROM party", conn);
                // Add the parameters to the SQL command

                // Execute the SQL command and get the new party_id.
                //Convert the new party_id to an int32 and set it to the partyId property of the party object
               
                return "https://localhost:44315/tinder/" +(Convert.ToInt32(cmd.ExecuteScalar()) +1);
                
                // ExecuteScalar returns the first column of the first row in the result set returned by the query.
               //return party with updated new party_id
            }
        }


       /* /// <summary>
        /// TODO: ADD THIS METHOD
        /// Update a party in the database using a Party object
        /// Takes in a Party object and returns the updated party
        /// </summary>
        public Party UpdateParty(Party updatedParty)
        {
            // Using a connection to the database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open(); //Open the connection to the DB    

                // TODO: Create a new SQL command that updates a party in the database
                //SqlCommand cmd = new SqlCommand("UPDATE ");
            }
            return new Party();
        }

        /// <summary>
        /// TODO: ADD THIS METHOD
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool DeleteParty(int partyId)
        {
            throw new NotImplementedException();
        }*/


    }
}
