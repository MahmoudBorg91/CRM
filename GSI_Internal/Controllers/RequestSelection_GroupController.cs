using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class RequestSelection_GroupController : Controller
    {
        private readonly IRequestSelection_GroupRepo _requestSelectionGroupRepo;

        public RequestSelection_GroupController(IRequestSelection_GroupRepo requestSelectionGroupRepo)
        {
            _requestSelectionGroupRepo = requestSelectionGroupRepo;
        }
        public IActionResult Index()
        {
            var data = _requestSelectionGroupRepo.GetAll().Select(a => new RequestSelection_GroupVM()
            {
                ID = a.ID,
                Selection_GroupName_Arab = a.Selection_GroupName_Arab,
                Selection_GroupName_English = a.Selection_GroupName_English
            });
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        
        public IActionResult Create(RequestSelection_GroupVM obj)
        {
            if (ModelState.IsValid)
            {


                RequestSelection_Group newobj = new RequestSelection_Group();
                newobj.ID = obj.ID;
                newobj.Selection_GroupName_Arab = obj.Selection_GroupName_Arab;
                newobj.Selection_GroupName_English = obj.Selection_GroupName_English;
               
                _requestSelectionGroupRepo.AddObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Edit(int id)
        {
            var data = _requestSelectionGroupRepo.GetByID(id);
            RequestSelection_GroupVM obj = new RequestSelection_GroupVM();
            obj.ID = data.ID;
            obj.Selection_GroupName_Arab = data.Selection_GroupName_Arab;
            obj.Selection_GroupName_English = data.Selection_GroupName_English;
           


            return View(obj);
        }

        [HttpPost]
       
        public IActionResult Edit(RequestSelection_GroupVM obj)
        {
            if (ModelState.IsValid)
            {


                RequestSelection_Group newobj = new RequestSelection_Group();
                newobj.ID = obj.ID;
                newobj.Selection_GroupName_Arab = obj.Selection_GroupName_Arab;
                newobj.Selection_GroupName_English = obj.Selection_GroupName_English;
              




                _requestSelectionGroupRepo.UpdateObj(newobj);
                return RedirectToAction("index");

            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var data = _requestSelectionGroupRepo.GetByID(id);
            RequestSelection_GroupVM obj = new RequestSelection_GroupVM();
            obj.ID = data.ID;
            obj.Selection_GroupName_Arab = data.Selection_GroupName_Arab;
            obj.Selection_GroupName_English = data.Selection_GroupName_English;
           
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
      
        public IActionResult ConfirmDelte(int id)
        {
            var data = _requestSelectionGroupRepo.DeleteObj(id);
            return RedirectToAction("index");
        }
    }
}
