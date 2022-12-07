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

        public PartySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


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



        // Get all parties based on the user 
        public IList<Party> GetParties(int userId)
        {
            IList<Party> parties = new List<Party>();

            //Restaurant restaurant = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM party", conn);
                /*                cmd.Parameters.AddwithVualue("@...", ...)
                */

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Party party = CreatePartyFromReader(reader);
                    parties.Add(party);
                }

            }
            return parties;
        }

        private Party CreatePartyFromReader(SqlDataReader reader)
        {
            Party party = new Party();
            party.PartyId = Convert.ToInt32(reader["party_id"]);
            party.Location = Convert.ToString(reader["location"]);
            party.Owner = Convert.ToString(reader["owner"]);
            party.NameOfParty = Convert.ToString(reader["name_of_party"]);
            return party;
        }





    }
}
