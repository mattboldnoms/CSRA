using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSRA.Models.ReceptionViewModels;
using CSRA.Data;

namespace CSRA.Controllers
{
    public class ReceptionController : Controller
    {
        private readonly CsraContext _context;

        public ReceptionController(CsraContext context)
        {
            _context = context;
        }

        // GET: Reception
        public ActionResult ExpectedToday()
        {
            var vm = new List<PrisonerListItemViewModel>();

            var prisoners = _context.Prisoners.ToList();

            foreach (var prisoner in prisoners)
            {
                var prisonerVm = new PrisonerListItemViewModel();

                prisonerVm.Firstname = prisoner.Firstname;
                prisonerVm.Surname = prisoner.LastName;
                prisonerVm.NomisId = prisoner.NomisId;
                prisonerVm.Id = prisoner.PrisonerID;
                prisonerVm.DoB = prisoner.DoB;
                prisonerVm.FromLocation = prisoner.FromLocation.Name;

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