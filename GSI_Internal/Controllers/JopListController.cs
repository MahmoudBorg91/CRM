using AutoMapper;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.JopListRepo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSI_Internal.Controllers
{
    public class JopListController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IJopListRepocs _jopListRepocs;

        public JopListController(IMapper mapper , IJopListRepocs jopListRepocs)
        {
            _mapper = mapper;
            _jopListRepocs = jopListRepocs;
        }
        public IActionResult Index()
        {
            var data = _jopListRepocs.GetAll();
            var map = _mapper.Map<IEnumerable<JopList_VM>>(data);
            return View(map);
          
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(JopList_VM obj)
        {
            if (ModelState.IsValid)
            {


                var mapNewObj = _mapper.Map<JopList>(obj);
                _jopListRepocs.AddObj(mapNewObj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int Id)
        {
            var data = _jopListRepocs.GetByID(Id);
            var map = _mapper.Map<JopList_VM>(data);
            return View(map);
        }

        [HttpPost]
        public IActionResult Edit(JopList_VM obj)
        {
            if (ModelState.IsValid)
            {


                var mapNewObj = _mapper.Map<JopList>(obj);
                _jopListRepocs.UpdateObj(mapNewObj);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var data = _jopListRepocs.GetByID(id);
            var map = _mapper.Map<JopList_VM>(data);
            return View(map);
        }
        [ActionName("Delete")]
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var deleteData = _jopListRepocs.DeleteObj(id);
            return View();
        }

    }
}
