﻿using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.TransactionGroupRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
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
        public IActionResult Create(TransactionGroupVM obj)
        {
            if (ModelState.IsValid)
            {
                string GroupPhotPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/Image/GroupTransPhoto/";
                string Groupfilename = Guid.NewGuid() + System.IO.Path.GetFileName(obj.logo.FileName);
                obj.logo.CopyTo(new System.IO.FileStream(GroupPhotPath + Groupfilename, System.IO.FileMode.Create));

                // if file null or not 
               // var imgUrl = _fileHandling.UploadFile(obj.logo, "GroupTransPhoto");

                TransactionGroup newobj = new TransactionGroup();
                newobj.ID = obj.ID;
                newobj.TransactionGroup_NameArabic = obj.TransactionGroup_NameArabic;
                newobj.TransactionGroup_NameEnglish = obj.TransactionGroup_NameEnglish;
                newobj.logo = Groupfilename;
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
            

            return View(obj);
        }

        [HttpPost]
        [Authorize(Permissions.Enitiy.Edit)]
        public IActionResult Edit(TransactionGroupVM obj)
        {
            if (ModelState.IsValid)
            {


                TransactionGroup newobj = new TransactionGroup();
                newobj.ID = obj.ID;
                newobj.TransactionGroup_NameArabic = obj.TransactionGroup_NameArabic;
                newobj.TransactionGroup_NameEnglish = obj.TransactionGroup_NameEnglish;
                if (obj.logo != null)
                {
                    if (obj.logo != null)
                    {
                       // var imgUrl = _fileHandling.UploadFile(obj.logo, "GroupTransPhoto", obj.image);
                        string filePath = Directory.GetCurrentDirectory() + "/wwwroot/Image/GroupTransPhoto/" + obj.logo.FileName;
                        System.IO.File.Delete(filePath);
                    }



                    newobj.logo = ProcessUploadedFile(obj);
                }

                


                repo.UpdateObj(newobj);
                return RedirectToAction("index");

            }
            else
            {
                return View();
            }
        }
        [Authorize(Permissions.Enitiy.Edit)]
        [Authorize(Permissions.Enitiy.Create)]
        private string ProcessUploadedFile(TransactionGroupVM model)
        {
            string uniqueFileName = null;
            string path = Directory.GetCurrentDirectory() + "/wwwroot/Image/GroupTransPhoto/" ;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.logo != null)
            {
                string uploadsFolder = Directory.GetCurrentDirectory() + "/wwwroot/Image/GroupTransPhoto/";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.logo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.logo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
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
