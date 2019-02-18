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
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;

        public ProductController(
            IProductAppService productAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_productAppService.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var productViewModel = _productAppService.GetById(id);

            return Response(productViewModel);
        }


        [HttpPost]
        public IActionResult Post([FromBody]ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _productAppService.Register(model);

            return Response(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            _productAppService.Update(model);

            return Response(model);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _productAppService.Remove(id);

            return Response();
        }

        [HttpGet]
        [Route("history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var historyData = _productAppService.GetAllHistory(id);
            return Response(historyData);
        }
    }
}