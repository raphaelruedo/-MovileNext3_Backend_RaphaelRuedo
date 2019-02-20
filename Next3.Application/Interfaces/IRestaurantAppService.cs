using Next3.Application.EventSourcerNormalizers;
using Next3.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Next3.Application.Interfaces
{
    public interface IRestaurantAppService : IDisposable
    {
        void Register(RestaurantViewModel restaurantViewModel);
        void Update(RestaurantViewModel restaurantViewModel);
        void Remove(Guid id);
        RestaurantViewModel GetById(Guid id);
        IEnumerable<RestaurantViewModel> GetAll(int? pageIndex, int pageSize);
        IList<RestaurantHistoryData> GetAllHistory(Guid id);
        IEnumerable<RestaurantViewModel> GetClosest(double latitude, double longitude, double maxDistance);
    }
}
