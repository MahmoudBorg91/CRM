using AutoMapper;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.ContactUsRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GSI_Internal.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContatUsRepo _contatUsRepo;
        private readonly IMapper _mapper;

        public ContactUsController(IContatUsRepo contatUsRepo , IMapper mapper)
        {
            _contatUsRepo = contatUsRepo;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _contatUsRepo.GetAll();
            var map = _mapper.Map<IEnumerable<ContactUsVM>>(data);
            return View(map);
        }

        public IActionResult Create()
        {
            var exisiting = _contatUsRepo.GetAll().FirstOrDefault();
            if (exisiting == null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Edit");

            }


        }
        [HttpPost]
        public IActionResult Create(ContactUsVM obj)
        {
            if (ModelState.IsValid)
            {
               
                
                var mapNewObj = _mapper.Map<ContactUs>(obj);
                _contatUsRepo.AddObj(mapNewObj);
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Edit()
        {
            var data = _contatUsRepo.GetAll().FirstOrDefault();
            var map = _mapper.Map<ContactUsVM>(data);
            return View(map);
        }

        [HttpPost]
        public IActionResult Edit(ContactUsVM obj)
        {
            if (ModelState.IsValid)
            {


                var mapNewObj = _mapper.Map<ContactUs>(obj);
                _contatUsRepo.UpdateObj(mapNewObj);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
