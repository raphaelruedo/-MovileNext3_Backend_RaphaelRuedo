using System.Security.Claims;
using System.Threading.Tasks;
using Next3.Infra.CrossCutting.Identity.Models.AccountViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Next3.Domain.Core.Bus;
using Next3.Domain.Core.Notifications;
using Next3.Infra.CrossCutting.Identity.Models;

namespace Next3.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            INotificationHandler<DomainNotification> notifications,
            ILoggerFactory loggerFactory,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
            if (!result.Succeeded)
                NotifyError(result.ToString(), "Login failure");

            _logger.LogInformation(1, "User logged in.");
            return Response(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Restaurants", "Write"));

                await _signInManager.SignInAsync(user, false);
                _logger.LogInformation(3, "User created a new account with password.");
                return Response(model);
            }

            AddIdentityErrors(result);
            return Response(model);
        }
    }
}