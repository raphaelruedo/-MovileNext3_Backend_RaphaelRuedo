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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiController
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(
            IOrderAppService orderAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _orderAppService = orderAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_orderAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var orderViewModel = _orderAppService.GetById(id);

            return Response(orderViewModel);
        }


        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _orderAppService.Register(model);

            return Response(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _orderAppService.Update(model);

            return Response(model);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _orderAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var historyData = _orderAppService.GetAllHistory(id);
            return Response(historyData);
        }
    }
}