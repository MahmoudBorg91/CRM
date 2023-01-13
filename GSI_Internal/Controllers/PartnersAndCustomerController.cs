using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.OurPartnersAndOurCustomerRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class PartnersAndCustomerController : Controller
    {
        private readonly IOurPartnersAndOurCustomerRepo _ourPartnersAndOurCustomerRepo;
        private readonly IFileHandling _fileHandling;

        public PartnersAndCustomerController(IOurPartnersAndOurCustomerRepo ourPartnersAndOurCustomerRepo, IFileHandling fileHandling)
        {
            _ourPartnersAndOurCustomerRepo = ourPartnersAndOurCustomerRepo;
            _fileHandling = fileHandling;
        }
        public IActionResult Index()
        {


            var data = _ourPartnersAndOurCustomerRepo.GetAll().Select(a => new OurPartnersAndOurCustomerVM()
                {
                    ID = a.ID,
                    NameAr = a.NameAr,
                    NameEnglish = a.NameEnglish,
                    NoteAr = a.NoteAr,
                    NoteEng = a.NoteEng,
                    Image = a.Image,

                    IsPartners = a.IsPartners
                }
            ).ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OurPartnersAndOurCustomerVM obj)
        {
            if (ModelState.IsValid)
            {
                OurPartnersAndOurCustomer newobj = new OurPartnersAndOurCustomer();
                newobj.NameAr = obj.NameAr;
                newobj.NameEnglish = obj.NameEnglish;
                newobj.NoteAr = obj.NoteAr;
                newobj.NoteEng= obj.NoteEng;
                newobj.IsPartners = obj.IsPartners;
                if (obj.ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.ImageIFormFile, "PartenerAndCustommer");

                    newobj.Image = imgUrl.Result;
                }

                _ourPartnersAndOurCustomerRepo.AddObj(newobj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            var data = _ourPartnersAndOurCustomerRepo.GetAll().Where(a=>a.ID==id ).Select(a => new OurPartnersAndOurCustomerVM()
            {
                ID = a.ID,
                NameAr = a.NameAr,
                NameEnglish = a.NameEnglish,
                NoteAr = a.NoteAr,
                NoteEng = a.NoteEng,
                Image = a.Image,

                IsPartners = a.IsPartners
            }).FirstOrDefault();
          
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(OurPartnersAndOurCustomerVM obj)
        {
            if (ModelState.IsValid)
            {
                var data = _ourPartnersAndOurCustomerRepo.GetByID(obj.ID);
                string oldImage = data.Image;
                OurPartnersAndOurCustomer newobj = new OurPartnersAndOurCustomer();
                newobj.ID=obj.ID;
                newobj.NameAr = obj.NameAr;
                newobj.NameEnglish = obj.NameEnglish;
                newobj.NoteAr = obj.NoteAr;
                newobj.NoteEng = obj.NoteEng;
                newobj.IsPartners = obj.IsPartners;
                if (obj.ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(obj.ImageIFormFile, oldImage, "PartenerAndCustommer");

                    newobj.Image = imgUrl.Result;
                }

                _ourPartnersAndOurCustomerRepo.UpdateObj(newobj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _ourPartnersAndOurCustomerRepo.GetAll().Where(a => a.ID == id).Select(a => new OurPartnersAndOurCustomerVM()
            {
                ID = a.ID,
                NameAr = a.NameAr,
                NameEnglish = a.NameEnglish,
                NoteAr = a.NoteAr,
                NoteEng = a.NoteEng,
                Image = a.Image,

                IsPartners = a.IsPartners
            }).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Confirmdelet(int id)
        {
            var data = _ourPartnersAndOurCustomerRepo.DeleteObj(id);
            return RedirectToAction("index");
        }

    }
}
