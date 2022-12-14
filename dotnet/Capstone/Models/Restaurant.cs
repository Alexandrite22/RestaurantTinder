using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Services;
namespace Capstone.Models
{
    public class Restaurant{
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public string Name { get; set; }
        public string ApiId { get; set; }
        public string YelpLink { get; set; }
        public string ImageLink { get; set; }
        public int review_count { get; set; }
        public double rating { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string display_address1 { get; set; }
        public string display_address2 { get; set; }
    }
}
