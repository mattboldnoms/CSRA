using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSRA.Models.ReceptionViewModels;
using CSRA.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CSRA.Application.UseCases.Prisoners;

namespace CSRA.Controllers
{
    public class ReceptionController : Controller
    {
        private IPrisonerInteractor prisonerInteractor;

        public ReceptionController(IPrisonerInteractor prisonerInteractor)
        {
            this.prisonerInteractor = prisonerInteractor;
        }

        // GET: Reception
        public async Task<ActionResult> ExpectedToday()
        {
            var response = await this.prisonerInteractor.GetPrisonersExpectedToday();
            
            return View(response.Prisoners);
        }

        public ActionResult AddPrisoner()
        {
            return View();
        }
    }
}