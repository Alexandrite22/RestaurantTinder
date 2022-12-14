using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantDao
    {
        void Create(Restaurant restaurant);
        Restaurant GetRestaurant(int restaurantId);
        IList<Restaurant> GetRestaurants(int partyId);
    }
}