using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSRA.Models.ReceptionViewModels;
using CSRA.Data;
using Microsoft.EntityFrameworkCore;
using CSRA.Services.IServices;
using AutoMapper;

namespace CSRA.Controllers
{
    public class ReceptionController : Controller
    {
        private CsraContext context;
        private IPrisonerService prisonerService;

        public ReceptionController(CsraContext context, IPrisonerService prisonerService)
        {
            this.context = context;
            this.prisonerService = prisonerService;
        }

        // GET: Reception
        public ActionResult ExpectedToday()
        {
            var vm = new List<PrisonerListItemViewModel>();

            var prisoners = this.prisonerService.GetAllPrisoners();

            foreach (var prisoner in prisoners)
            {
                var prisonerVm = Mapper.Map<PrisonerListItemViewModel>(prisoner);

                vm.Add(prisonerVm);
            }

            return View(vm);
        }

        public ActionResult AddPrisoner()
        {
            return View();
        }
    }
}