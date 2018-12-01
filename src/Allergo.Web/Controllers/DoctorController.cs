using System.Collections.Generic;
using System.Threading.Tasks;
using Allergo.Web.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace Allergo.Web.Controllers
{
    public class DoctorController: AllergoBaseController
    {
        public async Task<JsonResult> GetDoctors()
        {
            var model = new List<DoctorViewModel>
            {
                new DoctorViewModel
                {
                    FirstName = "Doctor",
                    LastName = "Dolittle",
                    Id = "abcdefghh"
                },
                new DoctorViewModel
                {
                    FirstName = "Second",
                    LastName = "Doktor",
                    Id = "abcdefgh2h"
                },
                new DoctorViewModel
                {
                    FirstName = "Third",
                    LastName = "Doc",
                    Id = "abcdefgh2h33"
                },
            };

            return await Task.FromResult(Json(model));
        }
    }
}
