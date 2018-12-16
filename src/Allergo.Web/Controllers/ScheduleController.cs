using System;
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
using Allergo.Common.Enums;
using Allergo.Web.ViewModels.Appointment;
using Microsoft.AspNetCore.Authorization;

namespace Allergo.Web.Controllers
{
    public class ScheduleController : AllergoBaseController
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
            var requestDto = Mapper.Map<GetScheduleRequestViewModel, GetScheduleRequestDto>(request);
            var modelDto = await _scheduleService.GetScheduleAsync(requestDto);

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

        [HttpGet]
        [Authorize(Roles = AllergoRoleNames.Doctor)]
        public async Task<JsonResult> GetAdmissionHours()
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            var requestDto = new GetScheduleRequestDto
            {
                DoctorId = currentUser.Id.ToString(),
                DayFrom = DateTime.UtcNow
            };

            var modelDto = await _scheduleService.GetScheduleAsync(requestDto);

            var result =
                Mapper.Map<ScheduleDto, ScheduleViewModel>(modelDto)
                    .DaySchedules
                    .OrderBy(x => x.StartTime)
                    .GroupBy(x => x.Day.DayOfWeek)
                    .OrderBy(x => x.Key)
                    .Select(x => new { Day = x.Key, AdmissionHours = x });

            return Json(result);
        }

        [HttpPost]
        [Authorize(Roles = AllergoRoleNames.Doctor)]
        public async Task CreateSchedule([FromBody] CreateScheduleRequestViewModel request)
        {
            var model = Mapper.Map<CreateScheduleRequestViewModel, CreateScheduleRequestDto>(request);
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            model.DoctorId = currentUser.Id;

            await _scheduleService.CreateScheduleAsync(model);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        }

        [HttpDelete]
        [Authorize(Roles = AllergoRoleNames.Doctor)]
        public async Task RemoveSchedule(string scheduleId)
        {
            var request = new RemoveScheduleRequestDto
            {
                ScheduleId = scheduleId
            };

            await _scheduleService.RemoveScheduleAsync(request);

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
