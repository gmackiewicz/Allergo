using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Web.ViewModels.Appoinment;
using Allergo.Web.ViewModels.Common;
using Allergo.Web.ViewModels.Schedule;
using Microsoft.AspNetCore.Mvc;

namespace Allergo.Web.Controllers
{
    public class ScheduleController: AllergoBaseController
    {
        public async Task<JsonResult> GetSchedule(string doctorId)
        {
            var model = new ScheduleViewModel();

            model.Doctor = new DoctorViewModel
            {
                FirstName = "Doktor",
                LastName = "Dolittle",
                Id = "abcdefghh"
            };

            var currentDay = new DateTime(2018, 12, 3, 8, 0, 0);
            model.DaySchedules = new List<DayScheduleViewModel>
            {
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>(),
                    Day = currentDay
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>(),
                    Day = currentDay.AddDays(1)
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>(),
                    Day = currentDay.AddDays(2)
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>
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
                    },
                    Day = currentDay.AddDays(3)
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>(),
                    Day = currentDay.AddDays(4)
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>
                    {
                        new AppointmentViewModel
                        {
                            Hour = 10,
                            Minutes = 15
                        },
                        new AppointmentViewModel
                        {
                            Hour = 10,
                            Minutes = 30
                        },
                        new AppointmentViewModel
                        {
                            Hour = 11,
                            Minutes = 15
                        }
                    },

                    Day = currentDay.AddDays(5)
                },
                new DayScheduleViewModel
                {
                    Appointments = new List<AppointmentViewModel>(),
                    Day = currentDay.AddDays(6)
                },
            };

            return await Task.FromResult(Json(model));
        }
    }
}
