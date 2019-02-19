using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Next3.Application.Interfaces;
using Next3.Application.ViewModels;
using Next3.Domain.Core.Bus;
using Next3.Domain.Core.Notifications;

namespace Next3.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ApiController
    {
        private readonly IRestaurantAppService _restaurantAppService;

        public RestaurantController(
            IRestaurantAppService restaurantAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _restaurantAppService = restaurantAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_restaurantAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var restaurantViewModel = _restaurantAppService.GetById(id);

            return Response(restaurantViewModel);
        }


        [HttpPost]
        [Authorize(Policy = "CanWriteRestaurantData")]
        public IActionResult Post([FromBody]RestaurantViewModel restaurantViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(restaurantViewModel);
            }
            
            _restaurantAppService.Register(restaurantViewModel);

            return Response(restaurantViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody]RestaurantViewModel restaurantViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(restaurantViewModel);
            }

            _restaurantAppService.Update(restaurantViewModel);

            return Response(restaurantViewModel);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _restaurantAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var historyData = _restaurantAppService.GetAllHistory(id);
            return Response(historyData);
        }
    }
}