using Next3.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Next3.Domain.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Restaurant GetByName(string name);
        Restaurant GetByAddress(string street, int number);
        IQueryable<Restaurant> GetClosest(double latitude, double longitude, double maxDistance);
    }
}
