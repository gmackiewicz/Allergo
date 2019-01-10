using Allergo.Account.Contracts;
using Allergo.Appointment.Contracts;
using Allergo.Appointment.Dto;
using Allergo.Web.ViewModels.Appointment;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Allergo.Web.Controllers
{
    public class AppointmentController: AllergoBaseController
    {
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(
            IUserService userService,
            IAppointmentService appointmentService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<JsonResult> SetAppointment([FromBody] CreateAppointmentRequestViewModel request)
        {
            var model = Mapper.Map<CreateAppointmentRequestViewModel, CreateAppointmentRequestDto>(request);

            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);
            model.UserId = currentUser.Id;

            await _appointmentService.CreateAppointmentAsync(model);
            return await Task.FromResult(Json("ok"));
        }

        [HttpPost]
        public async Task CancelAppointment([FromBody] CancelAppointmentRequestViewModel request)
        {
            await Task.CompletedTask;
        }

        public async Task<JsonResult> GetAppointments([FromBody]GetAppointmentsRequestViewModel request)
        {
            return await Task.FromResult(Json("ok"));
        }

        public async Task<JsonResult> GetUserCompletedAppointments()
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);

            var result = _appointmentService.GetUserAppointments(currentUser.Id, DateTime.Now);

            return Json(result);
        }

        public async Task<JsonResult> GetDoctorCompletedAppointments()
        {
            var currentUser = await _userService.GetUserByName(HttpContext.User.Identity.Name);

            var result = _appointmentService.GetDoctorAppointments(currentUser.Id, DateTime.Now);

            return Json(result);
        }

        public async Task<JsonResult> SetAppointmentDiagnosis([FromBody] CreateAppointmentDiagnosisRequestViewModel request)
        {
            var appointment = await _appointmentService.GetAppointmentById(request.AppointmentId);
            appointment.Diagnosis = request.Diagnosis;
            await _appointmentService.UpdateAppointmentAsync(appointment);

            return await Task.FromResult(Json("ok"));
        }
    }
}
