using Allergo.Account.Contracts;
using Allergo.Common.Enums;
using Allergo.Schedule.Contracts;
using Allergo.Schedule.Dto;
using Allergo.Web.ViewModels.Appointment;
using Allergo.Web.ViewModels.Schedule;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
            foreach (var daySchedule in model.DaySchedules)
            {
                daySchedule.Appointments = new List<AppointmentViewModel>();
                for (TimeSpan i = daySchedule.StartTime; i < daySchedule.EndTime; i= i.Add(TimeSpan.FromMinutes(15)))
                {
                    daySchedule.Appointments.Add(new AppointmentViewModel
                    {
                        Hour = i.Hours,
                        Minutes = i.Minutes
                    });
                }
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
