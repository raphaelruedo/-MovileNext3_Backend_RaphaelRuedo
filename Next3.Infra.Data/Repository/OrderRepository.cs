using Microsoft.EntityFrameworkCore;
using Next3.Domain.Interfaces;
using Next3.Domain.Models;
using Next3.Infra.Data.Context;
using System;
using System.Linq;

namespace Next3.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Next3Context context)
            : base(context)
        {

        }

        public Order GetOpenOrderByUser(Guid userId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(o => o.UserId == userId);
        }
    }
}
