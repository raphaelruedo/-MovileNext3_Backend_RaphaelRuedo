using Next3.Domain.Models;

namespace Next3.Domain.Interfaces
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        Restaurant GetByName(string name);
    }
}
