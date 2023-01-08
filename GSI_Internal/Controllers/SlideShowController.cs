using System;
using System.IO;
using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.ApiRepositry.Services;
using GSI_Internal.Repositry.SlideShowRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class SlideShowController : Controller
    {
        private readonly ISlideShowRepo _showRepo;
        private readonly IFileHandling _fileHandling;

        public SlideShowController(ISlideShowRepo showRepo, IFileHandling fileHandling)
        {
            _showRepo = showRepo;
            _fileHandling = fileHandling;
        }
        public IActionResult Index()
        {
            var data = _showRepo.GetAll().Select(a => new SlideShowVM()
            {
                ID = a.ID,
                ReSizeme_Arabic = a.ReSizeme_Arabic,
                ReSizeme_English = a.ReSizeme_English,
                SlideImage = a.SlideImage,
                Title_English = a.Title_English,
                Title_Arabic = a.Title_Arabic
            });
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SlideShowVM obj)
        {
            if (ModelState.IsValid)
            {
                SlideShow newobj = new SlideShow();

                if (obj.SlideImageFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.SlideImageFormFile, "SlideShow");

                    newobj.SlideImage = imgUrl.Result;
                }


         
               
                newobj.ID = obj.ID;
                newobj.ReSizeme_Arabic = obj.ReSizeme_Arabic;
                newobj.ReSizeme_English = obj.ReSizeme_English;
                newobj.Title_Arabic=obj.Title_Arabic;
                newobj.Title_English=obj.Title_English;
               // newobj.SlideImage= Slidefilename;
               
                _showRepo.AddObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
  
        public IActionResult Edit(int ID)
        {
            var data = _showRepo.GetByID(ID);
            SlideShowVM obj = new SlideShowVM();
            obj.ID = data.ID;
            obj.ReSizeme_Arabic = data.ReSizeme_Arabic;
            obj.ReSizeme_English = data.ReSizeme_English;
            obj.SlideImage = data.SlideImage;
            obj.Title_Arabic=data.Title_Arabic;
            obj.Title_English=data.Title_English;


           

            return View(obj);
        }


    
        [HttpPut]
        public IActionResult Edit(SlideShowVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = _showRepo.GetByID(obj.ID);
                string oldImage = data.SlideImage;

                SlideShow newobj = new SlideShow();
                newobj.ID = obj.ID;
                newobj.ReSizeme_Arabic = obj.ReSizeme_Arabic;
                newobj.ReSizeme_English = obj.ReSizeme_English;
                newobj.Title_Arabic = obj.Title_Arabic;
                newobj.Title_English = obj.Title_English;
                if (obj.SlideImageFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.SlideImageFormFile, "SlideShow", oldImage);

                    newobj.SlideImage = imgUrl.Result;

                }






                _showRepo.UpdateObj(newobj);
                return RedirectToAction("index");

            }
            else
            {
                return View();
            }



           
        }


      

        public IActionResult Delete(int id)
        {
            var data = _showRepo.GetByID(id);
            SlideShowVM obj = new SlideShowVM();
            
            obj.ID = data.ID;
            obj.ReSizeme_Arabic = data.ReSizeme_Arabic;
            obj.ReSizeme_English = data.ReSizeme_English;
            obj.SlideImage = data.SlideImage;
            obj.Title_Arabic = data.Title_Arabic;
            obj.Title_English = data.Title_English;
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelte(int id)
        {
            var data = _showRepo.DeleteObj(id);
            return RedirectToAction("index");
        }


    }
}
