using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantDao
    {
        int Create(Restaurant restaurant);
        Restaurant GetRestaurant(int restaurantId);
        IList<Restaurant> GetRestaurants(int partyId);
        void CreateRestaurantFromBusinessAndParty(Business business, int partyId);
    }
}