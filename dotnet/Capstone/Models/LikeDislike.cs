using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class LikeDislike
    {
        public int LikeId { get; set; }
        public int GuestId { get; set; }
        public int RestaurantId { get; set; }
        public string LikeStatus { get; set; }
    }
}
