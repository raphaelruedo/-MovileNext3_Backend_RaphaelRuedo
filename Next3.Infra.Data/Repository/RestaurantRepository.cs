using Microsoft.EntityFrameworkCore;
using Next3.Domain.Interfaces;
using Next3.Domain.Models;
using Next3.Infra.Data.Context;
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
    }
}
