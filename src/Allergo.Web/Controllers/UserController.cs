using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Allergo.Web.Controllers
{
    public class UserController : AllergoBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAll(int take = 20, int skip = 0)
        {
            var result = await _userService.GetAll(take, skip);
            return Json(result);
        }

        [HttpPut]
        public async Task<JsonResult> Edit([FromBody] EditUserViewModel viewModel)
        {
            var result = await _userService.EditUser(viewModel);
            return Json(result);
        }
    }
}
