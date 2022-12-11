using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequestSelection_GroupRepo;
using GSI_Internal.Repositry.TransiactionItem_Selection_Repo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class TransiactionItem_SelectionController : Controller
    {
        private readonly ITransiactionItem_SelectionRepo _transiactionItemSelectionRepo;
        private readonly IRequestSelection_GroupRepo _selectionGroupRepo;

        public TransiactionItem_SelectionController(ITransiactionItem_SelectionRepo transiactionItemSelectionRepo ,IRequestSelection_GroupRepo selectionGroupRepo )
        {
            _transiactionItemSelectionRepo = transiactionItemSelectionRepo;
            _selectionGroupRepo = selectionGroupRepo;
        }
        public IActionResult Index()
        {
            var data = _transiactionItemSelectionRepo.GetAll().Select(a => new TransiactionItem_SelectionVM()
            {
                ID = a.ID,
                SelectionName_English = a.SelectionName_English,
                SelectionName_Arabic = a.SelectionName_Arabic,
                Selection_GroupName_Arab = _selectionGroupRepo.GetAll().Where(g=>g.ID==a.SelectionGroupID).Select(a=>a.Selection_GroupName_Arab).FirstOrDefault(),
                Selection_GroupName_English = _selectionGroupRepo.GetAll().Where(g => g.ID == a.SelectionGroupID).Select(a => a.Selection_GroupName_English).FirstOrDefault(),

            });
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.SelectGroupSelection = _selectionGroupRepo.GetAll().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(TransiactionItem_SelectionVM obj)
        {
            if (ModelState.IsValid)
            {
                TransiactionItem_Selection newobj = new TransiactionItem_Selection();
                newobj.ID = obj.ID;
                newobj.SelectionName_Arabic = obj.SelectionName_Arabic;
                newobj.SelectionName_English = obj.SelectionName_English;
                newobj.SelectionGroupID=obj.SelectionGroupID;
                _transiactionItemSelectionRepo.AddObj(newobj);
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Edit(int Id)
        {
            ViewBag.SelectGroupSelection = _selectionGroupRepo.GetAll().ToList();
            var data = _transiactionItemSelectionRepo.GetByID(Id);
            TransiactionItem_SelectionVM obj = new TransiactionItem_SelectionVM();
            obj.ID = data.ID;
            obj.SelectionName_Arabic = data.SelectionName_Arabic;
            obj.SelectionName_English = data.SelectionName_English;
            obj.SelectionGroupID=data.SelectionGroupID;
            return View(obj);
        }
        [HttpPost]
      
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransiactionItem_SelectionVM obj)
        {
            if (ModelState.IsValid)
            {
                TransiactionItem_Selection newobj = new TransiactionItem_Selection();
                newobj.ID = obj.ID;
                newobj.SelectionName_Arabic = obj.SelectionName_Arabic;
                newobj.SelectionName_English = obj.SelectionName_English;
                 newobj.SelectionGroupID=obj.SelectionGroupID;
                _transiactionItemSelectionRepo.UpdateObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int Id)
        {
            var data = _transiactionItemSelectionRepo.GetByID(Id);
            TransiactionItem_SelectionVM obj = new TransiactionItem_SelectionVM();
            obj.ID = data.ID;
            obj.SelectionName_Arabic = data.SelectionName_Arabic;
            obj.SelectionName_English = data.SelectionName_English;
            obj.SelectionGroupID=data.SelectionGroupID;

            return View(obj);

        }

        [HttpPost]
        [ActionName("Delete")]
       
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var data = _transiactionItemSelectionRepo.DeleteObj(id);
            return RedirectToAction("index");
        }
    }
}
