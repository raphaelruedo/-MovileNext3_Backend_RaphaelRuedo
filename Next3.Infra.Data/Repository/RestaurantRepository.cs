using Microsoft.EntityFrameworkCore;
using Next3.Domain.Interfaces;
using Next3.Domain.Models;
using Next3.Infra.Data.Context;
using System;
using System.Linq;

namespace Next3.Infra.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(Next3Context context)
            : base(context)
        {

        }

        public Restaurant GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

        public Restaurant GetByAddress(string street, int number)
        {
            return DbSet.AsNoTracking().FirstOrDefault(r => r.Address.Street == street && r.Address.Number == number);
        }

        public IQueryable<Restaurant> GetClosest(double latitude, double longitude, double maxDistance)
        {
            var closestRestaurants = (from restaurant in DbSet.AsNoTracking().Include(r => r.Address)
                                      let distance = (6371 * Math.Acos(Math.Cos(latitude * Math.PI / 180) * Math.Cos(restaurant.Address.Latitude * Math.PI / 180)
                                       * Math.Cos((restaurant.Address.Longitude * Math.PI / 180) - (longitude * Math.PI / 180)) + Math.Sin(latitude * Math.PI / 180) *
                                       Math.Sin(restaurant.Address.Latitude * Math.PI / 180)))
                                      where distance < maxDistance
                                      orderby distance
                                      select restaurant
                                            );
            return closestRestaurants;
        }
    }
}
