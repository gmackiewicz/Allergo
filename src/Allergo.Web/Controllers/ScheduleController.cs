using Allergo.Account.Contracts;
using Allergo.Schedule.Contracts;
using Allergo.Schedule.Dto;
using Allergo.Web.ViewModels.Appointment;
using Allergo.Web.ViewModels.Schedule;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Allergo.Web.ViewModels.Appointment;

namespace Allergo.Web.Controllers
{
    public class ScheduleController: AllergoBaseController
    {
        private readonly IScheduleService _scheduleService;
        private readonly IUserService _userService;

        public ScheduleController(
            IScheduleService scheduleService,
            IUserService userService)
        {
            _scheduleService = scheduleService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<JsonResult> GetSchedule([FromBody]GetScheduleRequestViewModel request)
        {
            var modelDto = await _scheduleService.GetScheduleAsync(
                Mapper.Map<GetScheduleRequestViewModel, GetScheduleRequestDto>(request));

            var model = Mapper.Map<ScheduleDto, ScheduleViewModel>(modelDto);
            var daySchedule = model.DaySchedules.FirstOrDefault();
            if (daySchedule != null)
            {
                daySchedule.Appointments = new List<AppointmentViewModel>
                {
                    new AppointmentViewModel
                    {
                        Hour = 13,
                        Minutes = 15
                    },
                    new AppointmentViewModel
                    {
                        Hour = 13,
                        Minutes = 45
                    },
                    new AppointmentViewModel
                    {
                        Hour = 14,
                        Minutes = 0
                    }
                };
            }

            return Json(model);
        }

        [HttpPost]
        public async Task CreateSchedule([FromBody] CreateScheduleRequestViewModel request)
        {
            var model = Mapper.Map<CreateScheduleRequestViewModel, CreateScheduleRequestDto>(request);
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            model.DoctorId = currentUser.Id;

            await _scheduleService.CreateScheduleAsync(model);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        }

        [HttpDelete]
        public async Task RemoveSchedule([FromBody] RemoveScheduleRequestViewModel request)
        {
            var model = Mapper.Map<RemoveScheduleRequestViewModel, RemoveScheduleRequestDto>(request);

            await _scheduleService.RemoveScheduleAsync(model);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
