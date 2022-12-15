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
        /// Create a new party in the database from a Party object
        /// Takes in a Party object and returns the new party ID
        /// </summary>
        public Party CreateParty(Party party)
        {
            party.InviteLink = GetNextPartyLink();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open(); //Open the connection to the DB    

                // Create a new SQL command that inserts a new party into the database and returns the new party_id
                SqlCommand cmd = new SqlCommand("INSERT INTO party (location, owner, name_of_party, description, invite_link, date, party_invite_code) VALUES (@location, @owner, @name_of_party, @description, @invite_link, @date, @party_invite_code); SELECT @@IDENTITY;", conn);
                // Add the parameters to the SQL command
                cmd.Parameters.AddWithValue("@location", party.Location);
                cmd.Parameters.AddWithValue("@owner", 1);
                cmd.Parameters.AddWithValue("@name_of_party", party.Name);
                cmd.Parameters.AddWithValue("@description", party.Description);
                cmd.Parameters.AddWithValue("@invite_link", party.InviteLink);                cmd.Parameters.AddWithValue("@date", party.Date);
                cmd.Parameters.AddWithValue("@party_invite_code", party.PartyInviteCode);

                party.PartyId = Convert.ToInt32(cmd.ExecuteScalar());
                return party;
            }
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


        /// <summary>
        /// Update a party in the database using a Party object
        /// Takes in a Party object and returns the updated party
        /// </summary>        
        public void UpdateParty(int updatedPartyId, Party updatedParty)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE party SET location = @location, owner = @owner, name_of_party = @nameOfParty, date = @date, @party_invite_code = party_invite_code, description = @description WHERE party_id = @updatedPartyId", conn);
                cmd.Parameters.AddWithValue("@updatedPartyId", updatedPartyId);
                cmd.Parameters.AddWithValue("@location", updatedParty.Location);
                cmd.Parameters.AddWithValue("@owner", updatedParty.Owner);
                cmd.Parameters.AddWithValue("@nameOfParty", updatedParty.Name);
                cmd.Parameters.AddWithValue("@date", updatedParty.Date);
                cmd.Parameters.AddWithValue("@description", updatedParty.Description);
                cmd.Parameters.AddWithValue("@party_invite_code", updatedParty.PartyInviteCode);

            }
        }


        /// <summary>
        /// TODO: ADD THIS METHOD
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

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



        public string GetNextPartyLink()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                conn.Open(); //Open the connection to the DB    

                // Create a new SQL command that inserts a new party into the database and returns the new party_id
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM party", conn);
                // Add the parameters to the SQL command

                // Execute the SQL command and get the new party_id.
                //Convert the new party_id to an int32 and set it to the partyId property of the party object
                return "tinder/" + (Convert.ToInt32(cmd.ExecuteScalar()) + 1);

                // ExecuteScalar returns the first column of the first row in the result set returned by the query.
                //return party with updated new party_id
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
            // Convert the date from the database to a DateTime object and set it to the party.Date property
            party.Date = Convert.ToDateTime(reader["date"]);
            party.Description = Convert.ToString(reader["description"]);
            party.InviteLink = Convert.ToString(reader["invite_link"]);
            party.PartyInviteCode = Convert.ToString(reader["party_invite_code"]);
            return party;
        }
    }
}
