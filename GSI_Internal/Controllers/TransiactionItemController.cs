using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.TransactionGroupRepo;
using GSI_Internal.Repositry.TransactionItem_TypeRepo;
using GSI_Internal.Repositry.TransactionItemRepo;
using GSI_Internal.Repositry.TransactionSupGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace GSI_Internal.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TransiactionItemController : Controller
    {
        private readonly ITransactionItemRepo transactionItemRepo;
        private readonly ITransactionGroupRepo transactionGroupRepo;
        private readonly ITransactionSubGroupRepo transactionSubGroupRepo;
        private readonly IFileHandling _fileHandling;
        private readonly ITransactionItem_TypeRepo _itemTypeRepo;

        public TransiactionItemController(ITransactionItemRepo transactionItemRepo, ITransactionGroupRepo transactionGroupRepo, 
               ITransactionSubGroupRepo transactionSubGroupRepo, IFileHandling fileHandling, ITransactionItem_TypeRepo itemTypeRepo)
        {
            this.transactionItemRepo = transactionItemRepo;
            this.transactionGroupRepo = transactionGroupRepo;
            this.transactionSubGroupRepo = transactionSubGroupRepo;
            _fileHandling = fileHandling;
            _itemTypeRepo = itemTypeRepo;
        }


        [Authorize(Permissions.Sub_Services.View)]
        
        public IActionResult Index()
        {
            var Data = transactionItemRepo.GetAll().Select(a => new TransactionItemVM
            {
                ID = a.ID,
                TransactionNameArabic = a.TransactionNameArabic,
                TransactionNameEnglish = a.TransactionNameEnglish,
                GovernmentFees = a.GovernmentFees,
                Price = a.Price,
                TransactionGroupName = transactionGroupRepo.GetNameById(a.TransactionGroupID),
                TransactionGroupNameEnglis = transactionGroupRepo.GetNameEnglishById(a.TransactionGroupID),
                TransactionSubGroupName =transactionSubGroupRepo.GetAll().Where(x=>x.ID  ==a.TransactionSubGroupID).Select(a=>a.SubGroupNameArabic).FirstOrDefault(),
                TransactionSubGroupNameEnglish= transactionSubGroupRepo.GetAll().Where(x => x.ID == a.TransactionSubGroupID).Select(a => a.SubGroupNameEnglish).FirstOrDefault(),
                Item_TypeArabic = _itemTypeRepo.GetAll().Where(x=>x.ID == a.ItemServiceTypeID).Select(a=>a.NameArabic).FirstOrDefault(),
                Item_TypeEnglish = _itemTypeRepo.GetAll().Where(x => x.ID == a.ItemServiceTypeID).Select(a => a.NameEnglish).FirstOrDefault()

            });
            return View(Data);
        }

       

        [Authorize(Permissions.Sub_Services.Create)]
        [Authorize(Permissions.Sub_Services.Edit)]
       
       
        public JsonResult getGroup(int ID)
        {


            var data = transactionGroupRepo.GetAll().Where(a => a.ID == ID).Select(a => a).ToList();
            //data.Insert(0, new Applications { ID = 0, AppName="Select APP" });

            return Json(new SelectList(data, "ID", "TransactionGroup_NameArabic"));


        }
        [Authorize(Permissions.Sub_Services.Create)]
        [Authorize(Permissions.Sub_Services.Edit)]
      
        [Route("TransiactionItem/getSubGroup/{TransactionGroupID}")]
        public JsonResult getSubGroup(int TransactionGroupID)
        {

            var data = transactionSubGroupRepo.GetAll().Where(a => a.TransactionGroupID == TransactionGroupID).Select(a => new { a.ID, a.SubGroupNameArabic }).ToList();
            //var getselected = transactionItemRepo.
            
            //data.Insert(0, new Applications { ID = 0, AppName="Select APP" });

            return Json(new SelectList(data, "ID", "SubGroupNameArabic"));


        }


        [Authorize(Permissions.Sub_Services.Create)]
        [Authorize(Permissions.Sub_Services.Edit)]

        [Route("TransiactionItem/getSubCurrentGroup/{TransactionGroupID}")]
        public JsonResult getSubCurrentGroup(int TransactionGroupID)
        {

            var data = transactionSubGroupRepo.GetAll().Where(a => a.TransactionGroupID == TransactionGroupID).Select(a => new { a.ID, a.SubGroupNameArabic }).ToList();
            //data.Insert(0, new Applications { ID = 0, AppName="Select APP" });

            return Json(new SelectList(data, "ID", "SubGroupNameArabic"));


        }

        [Authorize(Permissions.Sub_Services.Create)]
      
      
        public IActionResult Create()
        {
            ViewBag.SelectGroupTransaction = transactionGroupRepo.GetAll().ToList();
            ViewBag.SelecttransactionSubGroup = transactionSubGroupRepo.GetAll().ToList();
            ViewBag.Item_Type = _itemTypeRepo.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [Authorize(Permissions.Sub_Services.Create)]

        [ValidateAntiForgeryToken]
        public IActionResult Create(TransactionItemVM obj)
        {
            if (ModelState.IsValid)
            {
                TransactionItem newobj = new TransactionItem();
                if (obj.ServicesPhotoVM != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.ServicesPhotoVM, "ItemTransPhoto");

                    newobj.ServicesPhoto = imgUrl.Result;
                }

                if (obj.IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.IconIFormFile, "ItemTransPhoto");

                    newobj.Icon = imgUrl.Result;
                }




                newobj.ID = obj.ID;
                newobj.TransactionNameArabic = obj.TransactionNameArabic;
                newobj.TransactionNameEnglish = obj.TransactionNameEnglish;
               
                newobj.Price = obj.Price;
                newobj.GovernmentFees = obj.GovernmentFees;
                newobj.TransactionGroupID = obj.TransactionGroupID;
                newobj.TransactionSubGroupID = obj.TransactionSubGroupID;
                newobj.ItemServiceTypeID = obj.Item_TypeID;
                newobj.ServicesDecription_Arabic = obj.ServicesDecription_Arabic;
                newobj.ServicesDecription_English = obj.ServicesDecription_English;
                newobj.Time_Services_English = obj.Time_Services_English;
                newobj.Time_Services_Arabic = obj.Time_Services_Arabic;
                newobj.SetInMostServices = obj.SetInMostServices;
                newobj.SetInMostServices_INSubGroup = obj.SetInMostServices_INSubGroup;
                newobj.IsNotAvailbale = obj.IsNotAvailbale;
                newobj.Services_Conditions_Arabic = obj.Services_Conditions_Arabic;
                newobj.Services_Conditions_English=obj.Services_Conditions_English;
                transactionItemRepo.AddObj(newobj);
                return RedirectToAction("Index");


            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Sub_Services.Edit)]

     
        public IActionResult Edit(int Id)
        {
            TransactionItemVM obj = new TransactionItemVM();
            ViewBag.SelectGroupTransaction = transactionGroupRepo.GetAll().ToList();
            ViewBag.SelecttransactionSubGroup = transactionSubGroupRepo.GetAll().ToList();
            ViewBag.Item_Type = _itemTypeRepo.GetAll().ToList();
            var data = transactionItemRepo.GetByID(Id);
            
            obj.ID = data.ID;
            obj.TransactionNameArabic = data.TransactionNameArabic;
            obj.TransactionNameEnglish = data.TransactionNameEnglish;
            obj.Price = data.Price;
            obj.GovernmentFees = data.GovernmentFees;
            obj.TransactionGroupID = data.TransactionGroupID;
            obj.TransactionSubGroupID = data.TransactionSubGroupID;
            obj.Item_TypeID = data.ItemServiceTypeID;
            //obj.TransactionSubGroupVM = transactionSubGroupRepo.GetAll().Where(s => s.ID == obj.TransactionSubGroupID).Select(f=> new TransactionSubGroupVM()
            //{
            //    ID = f.ID,
            //    SubGroupNameArabic = f.SubGroupNameArabic,
            //    SubGroupNameEnglish = f.SubGroupNameEnglish,
            //    TransactionGroupID = f.TransactionGroupID
            //});
               
            obj.ServicesDecription_Arabic = data.ServicesDecription_Arabic;
            obj.ServicesDecription_English = data.ServicesDecription_English;
            obj.Time_Services_Arabic = data.Time_Services_Arabic;
            obj.Time_Services_English = data.Time_Services_English;
            obj.SetInMostServices = data.SetInMostServices;
            obj.SetInMostServices_INSubGroup = data.SetInMostServices_INSubGroup;
            obj.image = data.ServicesPhoto;
            obj.Services_Conditions_Arabic=data.Services_Conditions_Arabic;
            obj.Services_Conditions_English = data.Services_Conditions_English;
            obj.IsNotAvailbale = data.IsNotAvailbale;
            obj.Icon=data.Icon;
            return View(obj);
        }
        [HttpPost]
        [Authorize(Permissions.Sub_Services.Edit)]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TransactionItemVM obj)
        {
            if (ModelState.IsValid)
            {
                var editData = transactionItemRepo.GetByID(obj.ID);
                string oldImage = editData.ServicesPhoto;
                string oldIcon = editData.Icon;

                TransactionItem EditObj = new TransactionItem();
                EditObj.ID = obj.ID;
                EditObj.TransactionNameArabic = obj.TransactionNameArabic;
                EditObj.TransactionNameEnglish = obj.TransactionNameEnglish;
                EditObj.Price = obj.Price;
                EditObj.GovernmentFees = obj.GovernmentFees;
                EditObj.TransactionGroupID = obj.TransactionGroupID;
                EditObj.TransactionSubGroupID = obj.TransactionSubGroupID;
                editData.ItemServiceTypeID = obj.Item_TypeID;
                EditObj.ServicesDecription_Arabic = obj.ServicesDecription_Arabic;
                EditObj.ServicesDecription_English = obj.ServicesDecription_English;
                EditObj.Time_Services_Arabic = obj.Time_Services_English;
                EditObj.Time_Services_English = obj.Time_Services_English;
                EditObj.Services_Conditions_Arabic=obj.Services_Conditions_Arabic;
                EditObj.Services_Conditions_English=obj.Services_Conditions_English;
                EditObj.SetInMostServices = obj.SetInMostServices;
                EditObj.SetInMostServices_INSubGroup = obj.SetInMostServices_INSubGroup;
                EditObj.IsNotAvailbale = obj.IsNotAvailbale;
                if (obj.ServicesPhotoVM != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.ServicesPhotoVM, "ItemTransPhoto", oldImage);

                    EditObj.ServicesPhoto = imgUrl.Result;
                }
                if (obj.IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.IconIFormFile, "ItemTransPhoto", oldIcon);

                    EditObj.Icon = imgUrl.Result;
                }



                transactionItemRepo.UpdateObj(EditObj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Sub_Services.Delete)]

      
        public IActionResult Delete(int Id)
        {
            ViewBag.SelectGroupTransaction = new SelectList(transactionGroupRepo.GetAll(), "ID", "TransactionGroup_NameArabic", 1);
            ViewBag.SelecttransactionSubGroup = transactionSubGroupRepo.GetAll().ToList();
            var data = transactionItemRepo.GetByID(Id);
            TransactionItemVM obj = new TransactionItemVM();
            obj.ID = data.ID;
            
            obj.TransactionNameArabic = data.TransactionNameArabic;
            obj.TransactionNameEnglish = data.TransactionNameEnglish;
            obj.Price = data.Price;
            obj.GovernmentFees = data.GovernmentFees;
            obj.TransactionGroupID = data.TransactionGroupID;
          
            return View(obj);

        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Permissions.Sub_Services.Delete)]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int id)
        {
            var data = transactionItemRepo.DeleteObj(id);
            return RedirectToAction("index");
        }
    }
}
