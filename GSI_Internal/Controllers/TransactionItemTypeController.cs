using System.Linq;
using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.TransactionItem_TypeRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class TransactionItemTypeController : Controller
    {
        private readonly ITransactionItem_TypeRepo _itemTypeRepo;
        private readonly IFileHandling _fileHandling;

        public TransactionItemTypeController(ITransactionItem_TypeRepo itemTypeRepo , IFileHandling fileHandling)
        {
            _itemTypeRepo = itemTypeRepo;
            _fileHandling = fileHandling;
        }
        [Authorize(Permissions.Sub_Services.View)]
        public IActionResult Index()
        {
            var data = _itemTypeRepo.GetAll().Select(a => new TransactionItem_TypeVM
            {
                ID = a.ID,
                NameArabic = a.NameArabic,
                NameEnglish = a.NameEnglish,
                Icon = a.Icon
            }).ToList();
            return View(data);
        }
        [Authorize(Permissions.Sub_Services.Create)]
        public IActionResult Create()
        {

            return View();
        }
        [Authorize(Permissions.Sub_Services.Create)]
        [HttpPost]
        public IActionResult Create(TransactionItem_TypeVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionItem_Type newObj = new TransactionItem_Type();
                newObj.NameArabic = obj.NameArabic;
                newObj.NameEnglish = obj.NameEnglish;
                if (obj.IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.IconIFormFile, "TransactionItemType");

                    newObj.Icon = imgUrl.Result;
                }

                _itemTypeRepo.AddObj(newObj);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _itemTypeRepo.GetAll().Where(a => a.ID == id)
                .Select(a => new TransactionItem_TypeVM()
                {
                    ID = a.ID,
                    NameArabic = a.NameArabic,
                    NameEnglish = a.NameEnglish,
                    Icon = a.Icon
                }).FirstOrDefault();
            return View(data);
        }
        [Authorize(Permissions.Sub_Services.Edit)]
        [HttpPost]
        public IActionResult Edit(TransactionItem_TypeVM obj)
        {
            if (ModelState.IsValid)
            {
                var edita = _itemTypeRepo.GetByID(obj.ID);
                string oldImage = edita.Icon;

                TransactionItem_Type EditObj = new TransactionItem_Type();
                EditObj.ID = obj.ID;
                EditObj.NameArabic = obj.NameArabic;
                EditObj.NameEnglish = obj.NameEnglish;
                if (obj.IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.IconIFormFile, "TransactionItemType",oldImage);

                    EditObj.Icon = imgUrl.Result;
                }

                _itemTypeRepo.UpdateObj(EditObj);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var data = _itemTypeRepo.GetAll().Where(a => a.ID == id)
                .Select(a => new TransactionItem_TypeVM()
                {
                    ID = a.ID,
                    NameArabic = a.NameArabic,
                    NameEnglish = a.NameEnglish,
                    Icon = a.Icon
                }).FirstOrDefault();
            return View(data);
        }
        [Authorize(Permissions.Sub_Services.Delete)]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var data = _itemTypeRepo.DeleteObj(id);
            return RedirectToAction("index");
        }


    }

    
}
