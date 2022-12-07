using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public string ApiAddress { get; set; }
    }
}
