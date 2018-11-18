using Allergo.Account.Contracts;
using Allergo.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Allergo.Account.Models;

namespace Allergo.Web.Controllers
{
    public class AuthController : AllergoBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel model)
        {
            var token = await _authService.Register(model);
            return Json(token);
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] SignInViewModel model)
        {
            var token = await _authService.SignIn(model);
            return Json(token);
        }
    }
}
