using System.Threading.Tasks;
using Allergo.Web.ViewModels.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace Allergo.Web.Controllers
{
    public class AppointmentController: AllergoBaseController
    {
        [HttpPost]
        public async Task SetAppointment([FromBody] CreateAppointmentRequestViewModel request)
        {
            await Task.CompletedTask;
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
    }
}
