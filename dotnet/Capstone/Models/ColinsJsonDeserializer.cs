using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Capstone.Models
{

    public partial class Businesses
    {
        [JsonProperty("businesses")]
        public List<Business> BusinessesBusinesses { get; set; } = new List<Business>();

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }
        //public void UpdateBusinesses(Business business)
        //{
        //    BusinessesBusinesses.Add(business);
        //}
    }

    public partial class Business
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("review_count")]
        public int ReviewCount { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("coordinates")]
        public Center Coordinates { get; set; }

        [JsonProperty("transactions")]
        public List<string> Transactions { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("display_phone")]
        public string DisplayPhone { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Center
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip_code")]
        
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("display_address")]
        public List<string> DisplayAddress { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("center")]
        public Center Center { get; set; }
    }
}
