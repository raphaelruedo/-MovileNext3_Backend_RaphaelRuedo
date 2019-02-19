using Next3.Application.EventSourcerNormalizers;
using Next3.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Next3.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void Register(OrderViewModel orderViewModel);
        void Update(OrderViewModel orderViewModel);
        void Remove(Guid id);
        OrderViewModel GetById(Guid id);
        IEnumerable<OrderViewModel> GetAll();
        IList<OrderHistoryData> GetAllHistory(Guid id);
    }
}
