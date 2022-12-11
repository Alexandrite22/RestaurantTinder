using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IGuestDao
    {
        Guest GetGuest(int partyId);
        IList<Guest> GetGuests(int partyID);

        void DeleteGuest(int guestId);
    }
}