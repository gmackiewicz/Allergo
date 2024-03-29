﻿using System.Threading.Tasks;
using Allergo.Common.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Allergo.Web.Controllers
{
    public class DoctorController : AllergoBaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(
            IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<JsonResult> GetDoctors()
        {
            var model = await _doctorService.GetAllAsync();

            return await Task.FromResult(Json(model));
        }
    }
}
