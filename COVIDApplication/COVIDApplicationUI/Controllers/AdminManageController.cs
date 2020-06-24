using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.Accounts.Admin.ConfirmedDoctor;
using Application.Commands.Accounts.Admin.GetAllDoctorsForConfirmed;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace COVIDApplicationUI.Controllers
{
    public class AdminManageController : BaseController
    {

        public async Task<IActionResult> GetAllDoctors()
        {
            ViewData["url"] = @"C:\Users\User\source\repos\COVIDApplication\COVIDApplicationUI\wwwroot\imagesForValidation\2-768x432.png";
            return View(await Mediator.Send(new GetDoctorsListVm()));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDoctor([Bind("Email,returnUrl")] string Email, string returnUrl=null)
        {
            
            await Mediator.Send(new ConfirmedDoctorVm() { Email = Email });
            return Redirect(returnUrl);
        }
        
    }
}
