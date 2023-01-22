using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequestData_Repo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class RequestDataController : Controller
    {
        private readonly IRequest_DataRepo _repo;

        public RequestDataController(IRequest_DataRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var data= _repo.GetAll().Select(a=> new Request_DataVM()
            {
                ID = a.ID,
                RequestName = a.RequestName,
            }).ToList();
            return View(data);
        }


        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Request_DataVM obj)
        {
            if (ModelState.IsValid)
            {
                Requests_Data newRequestsData= new Requests_Data();
                newRequestsData.RequestName=obj.RequestName;
                _repo.AddObj(newRequestsData);
               return RedirectToAction("Index");
            }
            return View();
        }
       
        public IActionResult Edit(int id)
        {
            Request_DataVM data_VM = new Request_DataVM();
            var data = _repo.GetByID(id);
            data_VM.ID = data.ID;
            data_VM.RequestName = data.RequestName;
            return View(data_VM);

        }
        [HttpPost]
        public IActionResult Edit(Request_DataVM obj)
        {
            if (ModelState.IsValid)
            {
                Requests_Data newRequestsData = new Requests_Data();
                newRequestsData.ID = obj.ID;
                newRequestsData.RequestName = obj.RequestName;
                _repo.UpdateObj(newRequestsData);
                RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Request_DataVM data_VM = new Request_DataVM();
            var data = _repo.GetByID(id);
            data_VM.ID = data.ID;
            data_VM.RequestName = data.RequestName;
            return View(data_VM);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var data = _repo.DeleteObj(id);
            return View();
        }
    }
}
