using Microsoft.EntityFrameworkCore;
using Next3.Domain.Interfaces;
using Next3.Domain.Models;
using Next3.Infra.Data.Context;
using System.Linq;

namespace Next3.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Next3Context context)
            : base(context)
        {

        }

        public Product GetByName(string name)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }
    }
}
