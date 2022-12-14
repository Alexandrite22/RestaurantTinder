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
        public string ApiId { get; set; }
        public string YelpLink { get; set; }
        public string ImageUrl { get; set; }
    }
    public class RestaurantViewModel
    {
        public int RestaurantId { get; set; }
        public int PartyId { get; set; }
        public Business YelpData { get; set;}
    }
    //public class RestaurantViewModel
    //{
    //    public int RestaurantId { get; set; }
    //    public int PartyId { get; set; }
    //    public string ApiId { get; set; }
    //    public string Name { get; set; }
    //    public string YelpLink { get; set;}
    //    public string ImageUrl { get; set;}
    //    public bool IsClosed { get; set;}
    //    public int Review_count { get; set;}
    //    public float Rating { get; set;}
    //    public string Phone { get; set;}
    //    public string Display_phone { get; set;}
    //    public string AddressLine1 { get; set;}
    //    public string AddressLine2 { get; set;}
    //    public string City { get; set;}
    //    public string ZipCode { get; set;}
    //    public string LocationCounty { get; set;}
    //    public string State { get; set;}
    //    public string DisplayAddress { get; set;}
    //    public IList<string> Categories { get; set; }

    //}
    //public class RestaurantYelpModel
    //{
    //    public string id { get; set; }
    //    public string alias { get; set; }
    //    public string name { get; set; }
    //    public string image_url { get; set; }
    //    public bool is_closed { get; set; }
    //    public string url { get; set; }
    //    public int review_count { get; set; }
    //    public List<string> categories { get; set; }
    //    public double rating { get; set; }
    //    public List<string> coordinates { get; set; }
    //    public List<string> transactions { get; set; }
    //    public Location location { get; set; }
    //    public string phone { get; set; }
    //    public string display_phone { get; set; }
    //    public float distance { get; set; }
    //}
    //public class categories
    //{
    //    public string alias { get; set; }    //    public string name { get; set; }
    //}
    //public class coordinates
    //{
    //    public string alias { get; set; }    //    public string name { get; set; }
    //}
}
