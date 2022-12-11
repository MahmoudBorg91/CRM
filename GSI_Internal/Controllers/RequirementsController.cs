using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequirementsRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace GSI_Internal.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly IRequirementsRepo requirementsRepo;

        public RequirementsController(IRequirementsRepo requirementsRepo)
        {
            this.requirementsRepo = requirementsRepo;
        }
        [Authorize(Permissions.Requirements.View)]
     
        public IActionResult Index()
        {
            var data = requirementsRepo.GetAll().Select(a => new RequirementsVM { ID = a.ID, RequirementName_Arabic = a.RequirementName_Arabic, RequirementName_English = a.RequirementName_English });
            return View(data);
        }
        [Authorize(Permissions.Requirements.Create)]
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Permissions.Requirements.Create)]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RequirementsVM obj)
        {
            if (ModelState.IsValid)
            {
                Requirements newobj = new Requirements();
                newobj.ID = obj.ID;
                newobj.RequirementName_Arabic = obj.RequirementName_Arabic;
                newobj.RequirementName_English = obj.RequirementName_English;
                requirementsRepo.AddObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [Authorize(Permissions.Requirements.Edit)]
       
        public IActionResult Edit(int Id)
        {
            var data = requirementsRepo.GetByID(Id);
            RequirementsVM obj = new RequirementsVM();
            obj.ID = data.ID;
            obj.RequirementName_Arabic = data.RequirementName_Arabic;
            obj.RequirementName_English = data.RequirementName_English;
            return View(obj);
        }
        [HttpPost]
        [Authorize(Permissions.Requirements.Edit)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RequirementsVM obj)
        {
            if (ModelState.IsValid)
            {
                Requirements newobj = new Requirements();
                newobj.ID = obj.ID;
                newobj.RequirementName_English = obj.RequirementName_English;
                newobj.RequirementName_Arabic = obj.RequirementName_Arabic;
                requirementsRepo.UpdateObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Requirements.Delete)]
      
        public IActionResult Delete(int Id)
        {
            var data = requirementsRepo.GetByID(Id);
            RequirementsVM obj = new RequirementsVM();
            obj.ID = data.ID;
            obj.RequirementName_English = data.RequirementName_English;
            obj.RequirementName_Arabic = data.RequirementName_Arabic;

            return View(obj);

        }
        [Authorize(Permissions.Requirements.Delete)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var data = requirementsRepo.DeleteObj(id);
            return RedirectToAction("index");
        }
    }
}
