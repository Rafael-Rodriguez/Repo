using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>()
            {
                new Restaurant {ID = 1, Name ="Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian },
                new Restaurant {ID = 2, Name="Chico's Tacos", Location="Arizona", Cuisine=CuisineType.Mexican },
                new Restaurant {ID = 3, Name="My Hot Indian", Location="Texas", Cuisine=CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in _restaurants
                   orderby r.Name
                   select r;
        }
    }
}
