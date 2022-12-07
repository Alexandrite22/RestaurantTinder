using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Party
    {
        public int PartyId { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string NameOfParty { get; set; }

        public string InviteLink { get; set; }
    }

    public class PartyViewModel
    {
        public int PartyId { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string NameOfParty { get; set; }

        public string InviteLink { get; set; }

        public List<Guest> GuestList { get; set; }
        public List<Restaurant> RestaurantList { get; set; }
    }
}
