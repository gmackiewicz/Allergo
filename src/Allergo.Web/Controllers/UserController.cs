using System.Net;
using Allergo.Account.Contracts;
using Allergo.Account.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Allergo.Common.Enums;
using Allergo.Web.ViewModels.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Allergo.Web.Controllers
{
    [Authorize(Roles = AllergoRoleNames.Admin)]
    public class UserController : AllergoBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<JsonResult> GetUsers(int take = 20, int skip = 0)
        {
            var result = await _userService.GetUsersAsync(take, skip);
            return Json(result);
        }

        [HttpPut]
        public async Task Edit([FromBody] EditUserRequestViewModel viewModel)
        {
            var requestDto = Mapper.Map<EditUserRequestViewModel, EditUserRequestDto>(viewModel);

            await _userService.EditUserAsync(requestDto);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        }

        [HttpGet]
        public async Task<JsonResult> GetUser(string id)
        {
            var result = await _userService.GetUserAsync(id);
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetRoles()
        {
            var result = await _userService.GetRolesAsync();
            return Json(result);
        }
    }
}
