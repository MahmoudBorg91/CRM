using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.TransactionGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;


namespace GSI_Internal.Controllers
{
    public class TransiactionGroupController : Controller
    {
        private readonly ITransactionGroupRepo repo;
        private readonly IFileHandling _fileHandling;

        public TransiactionGroupController(ITransactionGroupRepo repo, IFileHandling fileHandling)
        {
            this.repo = repo;
            _fileHandling = fileHandling;
        }
      
        [Authorize(Permissions.Enitiy.View)]
        public IActionResult Index()
        {
            var data = repo.GetAll().Select(a => new TransactionGroupVM { ID = a.ID, TransactionGroup_NameArabic = a.TransactionGroup_NameArabic, TransactionGroup_NameEnglish = a.TransactionGroup_NameEnglish, image = a.logo });

            return View(data);
        }
        [Authorize(Permissions.Enitiy.Create)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Permissions.Enitiy.Create)]
        public  IActionResult  Create(TransactionGroupVM obj)
        {
            if (ModelState.IsValid)
            {
             
                TransactionGroup newobj = new TransactionGroup();
                if (obj.logo != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.logo, "GroupTransPhoto");

                    newobj.logo = imgUrl.Result;
                }



               
                newobj.ID = obj.ID;
                newobj.TransactionGroup_NameArabic = obj.TransactionGroup_NameArabic;
                newobj.TransactionGroup_NameEnglish = obj.TransactionGroup_NameEnglish;
                newobj.IsNotAvailbale = obj.IsNotAvailbale;
                repo.AddObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [Authorize(Permissions.Enitiy.Edit)]
        public IActionResult Edit(int id)
        {
            var data = repo.GetById(id);
            TransactionGroupVM obj = new TransactionGroupVM();
            obj.ID = data.ID;
            obj.TransactionGroup_NameEnglish = data.TransactionGroup_NameEnglish;
            obj.TransactionGroup_NameArabic = data.TransactionGroup_NameArabic;
            obj.image = data.logo;
            obj.Icon = data.Icon;
            obj.IsNotAvailbale=data.IsNotAvailbale;
            return View(obj);
        }

        [HttpPost]
        [Authorize(Permissions.Enitiy.Edit)]
        public IActionResult Edit(TransactionGroupVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = repo.GetById(obj.ID);
                string oldImage = data.logo;

                TransactionGroup newobj = new TransactionGroup();
                newobj.ID = obj.ID;
                newobj.TransactionGroup_NameArabic = obj.TransactionGroup_NameArabic;
                newobj.TransactionGroup_NameEnglish = obj.TransactionGroup_NameEnglish;
                newobj.IsNotAvailbale = obj.IsNotAvailbale;

                if (obj.logo != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.logo, "GroupTransPhoto",oldImage );

                    newobj.logo = imgUrl.Result;
                }

                if (obj.IconIFormFile  != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.IconIFormFile, "GroupTransPhoto", oldImage);

                    newobj.Icon = imgUrl.Result;
                }




                repo.UpdateObj(newobj);
                return RedirectToAction("index");

            }
            else
            {
                return View();
            }
        }
      
        [Authorize(Permissions.Enitiy.Delete)]
        public IActionResult Delete(int id)
        {
            var data = repo.GetById(id);
            TransactionGroupVM obj = new TransactionGroupVM();
            obj.ID = data.ID;
            obj.TransactionGroup_NameArabic = data.TransactionGroup_NameArabic;
            obj.TransactionGroup_NameEnglish = data.TransactionGroup_NameEnglish;
            obj.image = data.logo;
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Permissions.Enitiy.Delete)]
        public IActionResult ConfirmDelte(int id)
        {
            var data = repo.DeleteObj(id);
            return RedirectToAction("index");
        }

    }
}
