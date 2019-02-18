using Next3.Application.EventSourcerNormalizers;
using Next3.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Next3.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        void Register(ProductViewModel productViewModel);
        void Update(ProductViewModel productViewModel);
        void Remove(Guid id);
        ProductViewModel GetById(Guid id);
        IEnumerable<ProductViewModel> GetAll();
        IList<ProductHistoryData> GetAllHistory(Guid id);
    }
}
