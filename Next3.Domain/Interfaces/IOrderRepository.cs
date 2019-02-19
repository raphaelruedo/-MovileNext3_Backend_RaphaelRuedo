using Next3.Domain.Models;
using System;

namespace Next3.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order GetOpenOrderByUser(Guid userId);
    }
}
