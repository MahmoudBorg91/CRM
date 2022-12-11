using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GSI_Internal.Controllers
{
    public class TransiactionSubGroupController : Controller
    {
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;

        public TransiactionSubGroupController(ITransactionSubGroupRepo transactionSubGroupRepo, ITransactionGroupRepo transactionGroupRepo)
        {
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            this.transactionGroupRepo = transactionGroupRepo;
        }
        [Authorize(Permissions.Main_Services.View)]
    
        public IActionResult Index()
        {
            var Data = transactionSubGroupRepo.GetAll().Select(a => new TransactionSubGroupVM
            {
                ID = a.ID,
                SubGroupNameArabic = a.SubGroupNameArabic,
                SubGroupNameEnglish = a.SubGroupNameEnglish,
                TransactionGroupID = a.TransactionGroupID,
                TransactionGroupNameArabic = transactionGroupRepo.GetAll().Where(x => x.ID == a.TransactionGroupID).Select(a => a.TransactionGroup_NameArabic).SingleOrDefault()
          ,
                TransactionGroupNameEnglish = transactionGroupRepo.GetAll().Where(x => x.ID == a.TransactionGroupID).Select(a => a.TransactionGroup_NameEnglish).SingleOrDefault()
            });
            return View(Data);
        }
        [Authorize(Permissions.Main_Services.Create)]
       
        public IActionResult Create()
        {
            ViewBag.SelectGroupTransaction = new SelectList(transactionGroupRepo.GetAll(), "ID", "TransactionGroup_NameArabic", 1);
            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Main_Services.Create)]
        [ValidateAntiForgeryToken]

        public IActionResult Create(TransactionSubGroupVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionSubGroup newobj = new TransactionSubGroup();
                newobj.ID = obj.ID;
                newobj.SubGroupNameArabic = obj.SubGroupNameArabic;
                newobj.SubGroupNameEnglish = obj.SubGroupNameEnglish;
                newobj.TransactionGroupID = obj.TransactionGroupID;
                transactionSubGroupRepo.AddObj(newobj);
                return RedirectToAction("Index");


            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Main_Services.Edit)]
      
        public IActionResult Edit(int Id)
        {
            ViewBag.SelectGroupTransaction = new SelectList(transactionGroupRepo.GetAll(), "ID", "TransactionGroup_NameArabic", 1);
            var data = transactionSubGroupRepo.GetByID(Id);
            TransactionSubGroupVM obj = new TransactionSubGroupVM();
            obj.ID = data.ID;
            obj.SubGroupNameArabic = data.SubGroupNameArabic;
            obj.SubGroupNameEnglish = data.SubGroupNameEnglish;
            obj.TransactionGroupID = data.TransactionGroupID;
            return View(obj);
        }

        [HttpPost]
        [Authorize(Permissions.Main_Services.Edit)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransactionSubGroupVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionSubGroup EditObj = new TransactionSubGroup();
                EditObj.ID = obj.ID;
                EditObj.SubGroupNameArabic = obj.SubGroupNameArabic;
                EditObj.SubGroupNameEnglish = obj.SubGroupNameEnglish;
                EditObj.TransactionGroupID = obj.TransactionGroupID;
                transactionSubGroupRepo.UpdateObj(EditObj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Main_Services.Delete)]
       
        public IActionResult Delete(int Id)
        {
            ViewBag.SelectGroupTransaction = new SelectList(transactionGroupRepo.GetAll(), "ID", "TransactionGroup_NameArabic", 1);
            var data = transactionSubGroupRepo.GetByID(Id);
            TransactionSubGroupVM obj = new TransactionSubGroupVM();
            obj.ID = data.ID;
            obj.SubGroupNameArabic = data.SubGroupNameArabic;
            obj.SubGroupNameEnglish = data.SubGroupNameEnglish;
            obj.TransactionGroupID = data.TransactionGroupID;
            return View(obj);

        }
        [Authorize(Permissions.Main_Services.Delete)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var data = transactionSubGroupRepo.DeleteObj(id);
            return RedirectToAction("index");
        }

    }
}
