using Next3.Domain.Models;

namespace Next3.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
    }
}
