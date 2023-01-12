using System.Collections.Generic;
using AutoMapper;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.OurCompanyInfoRepo;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class OurCompanyInfoController : Controller
    {
        private readonly IOurCompanyInfoRepo _ourCompanyInfoRepo;
        private readonly IMapper _mapper;
        private readonly IFileHandling _fileHandling;

        public OurCompanyInfoController(IOurCompanyInfoRepo ourCompanyInfoRepo, IMapper mapper,
            IFileHandling fileHandling)
        {
            _ourCompanyInfoRepo = ourCompanyInfoRepo;
            _mapper = mapper;
            _fileHandling = fileHandling;
        }
        public IActionResult Index()
        {
            var data = _ourCompanyInfoRepo.GetAll();
            var map = _mapper.Map<IEnumerable<OurCompanyInfo_VM>>(data);
            return View(data);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(OurCompanyInfo_VM Obj)
        {

            if (ModelState.IsValid)
            {
                OurCompanyInfo newObj = new OurCompanyInfo();
                newObj.AboutUS_Englis = Obj.AboutUS_Englis;
                newObj.AboutUS_Arabic = Obj.AboutUS_Arabic;
                if (Obj.AboutUS_ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.AboutUS_ImageIFormFile, "CompanyInfo");
                    newObj.AboutUS_Image = imgUrl.Result;
                }
                if (Obj.AboutUS_IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.AboutUS_IconIFormFile, "CompanyInfo");
                    newObj.AboutUS_Icon = imgUrl.Result;
                }


                newObj.OurMission_Englis = Obj.OurMission_Englis;
                newObj.OurMission_Arabic = Obj.OurMission_Arabic;
                if (Obj.OurMission_ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurMission_ImageIFormFile, "CompanyInfo");
                    newObj.OurMission_Image = imgUrl.Result;
                }
                if (Obj.OurMission_IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurMission_IconIFormFile, "CompanyInfo");
                    newObj.OurMission_Icon = imgUrl.Result;
                }

                newObj.OurVision_Englis = Obj.OurVision_Englis;
                newObj.OurVision_Arabic = Obj.OurVision_Arabic;
                if (Obj.OurVision_ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurVision_ImageIFormFile, "CompanyInfo");
                    newObj.OurVision_Image = imgUrl.Result;
                }
                if (Obj.OurVision_IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurVision_IconIFormFile, "CompanyInfo");
                    newObj.OurVision_Icon = imgUrl.Result;
                }

                newObj.OurGoal_Englis = Obj.OurGoal_Englis;
                newObj.OurGoal_Arabic = Obj.OurGoal_Arabic;
                if (Obj.OurGoal_ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurGoal_ImageIFormFile, "CompanyInfo");
                    newObj.OurGoal_Image = imgUrl.Result;
                }
                if (Obj.OurGoal_IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurGoal_IconIFormFile, "CompanyInfo");
                    newObj.OurGoal_Icon = imgUrl.Result;
                }

                newObj.OurValues_Englis = Obj.OurValues_Englis;
                newObj.OurValues_Arabic = Obj.OurValues_Arabic;
                if (Obj.OurValues_ImageIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurValues_ImageIFormFile, "CompanyInfo");
                    newObj.OurValues_Image = imgUrl.Result;
                }
                if (Obj.OurValues_IconIFormFile != null)
                {
                    var imgUrl = _fileHandling.UploadFile(Obj.OurValues_IconIFormFile, "CompanyInfo");
                    newObj.OurValues_Icon = imgUrl.Result;
                }


                _ourCompanyInfoRepo.AddObj(newObj);
                return RedirectToAction("Index");




            }

            return View();
        }

        public IActionResult Edit()
        {
            var data = _ourCompanyInfoRepo.GetAll();
            var map = _mapper.Map<IEnumerable<OurCompanyInfo_VM>>(data);
            return View(data);
        }

    }
}
