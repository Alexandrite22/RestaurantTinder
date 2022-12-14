using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPartyDao
    {
        IList<Party> GetParties(int userId);
        Party GetParty(int partyId);
        Party CreateParty(Party newParty);
        
        void UpdateParty(int updatedPartyId, Party updatedParty);

        void DeleteParty(int partyId);
        string GetNextPartyLink();
    }
}