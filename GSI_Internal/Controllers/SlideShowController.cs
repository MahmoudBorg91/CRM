using System;
using System.IO;
using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.SlideShowRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class SlideShowController : Controller
    {
        private readonly ISlideShowRepo _showRepo;

        public SlideShowController(ISlideShowRepo showRepo)
        {
            _showRepo = showRepo;
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
                string SlidePhotPath = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/Image/SlideShow/";
                string Slidefilename = Guid.NewGuid() + System.IO.Path.GetFileName(obj.SlideImageFormFile.FileName);
                obj.SlideImageFormFile.CopyTo(new System.IO.FileStream(SlidePhotPath + Slidefilename, System.IO.FileMode.Create));

                SlideShow newobj = new SlideShow();
                newobj.ID = obj.ID;
                newobj.ReSizeme_Arabic = obj.ReSizeme_Arabic;
                newobj.ReSizeme_English = obj.ReSizeme_English;
                newobj.Title_Arabic=obj.Title_Arabic;
                newobj.Title_English=obj.Title_English;
                newobj.SlideImage= Slidefilename;
               
                _showRepo.AddObj(newobj);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        private string ProcessUploadedFile(SlideShowVM model)
        {
            string uniqueFileName = null;
            string path = Directory.GetCurrentDirectory() + "/wwwroot/Image/SlideShow/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (model.SlideImageFormFile != null)
            {
                string uploadsFolder = Directory.GetCurrentDirectory() + "/wwwroot/Image/SlideShow/";
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.SlideImageFormFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.SlideImageFormFile.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        public IActionResult Edit(int id)
        {
            var data = _showRepo.GetByID(id);
            SlideShowVM obj = new SlideShowVM();
            obj.ID = data.ID;
            obj.ReSizeme_Arabic = data.ReSizeme_Arabic;
            obj.ReSizeme_English = data.ReSizeme_English;
            obj.SlideImage = data.SlideImage;
            obj.Title_Arabic=data.Title_Arabic;
            obj.Title_English=data.Title_English;


           

            return View(obj);
        }

        [HttpPost]
       
        public IActionResult Edit(SlideShowVM obj)
        {
            if (ModelState.IsValid)
            {


                SlideShow newobj = new SlideShow();
                newobj.ID = obj.ID;
                newobj.ReSizeme_Arabic = obj.ReSizeme_Arabic;
                newobj.ReSizeme_English = obj.ReSizeme_English;
                newobj.Title_Arabic = obj.Title_Arabic;
                newobj.Title_English = obj.Title_English;
                if (obj.SlideImageFormFile != null)
                {
                    if (obj.SlideImageFormFile != null)
                    {
                        string filePath = Directory.GetCurrentDirectory() + "/wwwroot/Image/SlideShow/" + obj.SlideImageFormFile.FileName;
                        System.IO.File.Delete(filePath);
                    }



                    newobj.SlideImage = ProcessUploadedFile(obj);
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
