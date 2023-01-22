using System;
using System.Linq;
using System.Security.Claims;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequestActionRepo;
using GSI_Internal.Repositry.RequestData_Repo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class RequestMangmentController : Controller
    {
        private readonly IRequest_DataRepo _requestDataRepo;
        private readonly IReequstRepo _reequstRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestMangmentController(IRequest_DataRepo requestDataRepo, IReequstRepo reequstRepo, UserManager<ApplicationUser> _userManager)
        {
            _requestDataRepo = requestDataRepo;
            _reequstRepo = reequstRepo;
            this._userManager = _userManager;
        }
        public IActionResult Index()
        {
            var Data = _reequstRepo.GetAll().Select(a=>  new RequestAction_VM()
            {
                ID= a.ID,
                RequetDataID = a.RequetDataID,
                RequestName = _requestDataRepo.GetByID(a.RequetDataID).RequestName,
                RequestFromUserID = a.RequestFromUserID,
                RequestFromUserName = _userManager.Users.Where(c => c.Id == a.RequestFromUserID).Select(a => a.UserName).FirstOrDefault(),
                DateOfCreate = a.DateOfCreate,
                DateOfStartRequest = a.DateOfStartRequest,
                DateOfEndtRequest = a.DateOfEndtRequest,
                Note = a.Note,
                status = a.status,
                UserTakeAction = a.UserTakeAction,
                UserTakeActionName = _userManager.Users.Where(c => c.Id == a.UserTakeAction).Select(a => a.UserName).FirstOrDefault(),
                NoteStatus = a.NoteStatus



            }).ToList();
            return View(Data);
        }

        public IActionResult OpenRequestByStatus(int status)
        {
            var Data = _reequstRepo.GetAll().Where(a=>a.status==status).Select(a => new RequestAction_VM()
            {
                ID = a.ID,
                RequetDataID = a.RequetDataID,
                RequestName = _requestDataRepo.GetByID(a.RequetDataID).RequestName,
                RequestFromUserID = a.RequestFromUserID,
                RequestFromUserName = _userManager.Users.Where(c => c.Id == a.RequestFromUserID).Select(a => a.UserName).FirstOrDefault(),
                DateOfCreate = a.DateOfCreate,
                DateOfStartRequest = a.DateOfStartRequest,
                DateOfEndtRequest = a.DateOfEndtRequest,
                Note = a.Note,
                status = a.status,
                UserTakeAction = a.UserTakeAction,
                UserTakeActionName = _userManager.Users.Where(c => c.Id == a.UserTakeAction).Select(a => a.UserName).FirstOrDefault(),
                NoteStatus = a.NoteStatus



            }).ToList();
            return View();
        }

        public IActionResult CreateRequest()
        {
            ViewBag.SelectRequest = _requestDataRepo.GetAll().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateRequest(RequestAction_VM obj)
        {
            if (ModelState.IsValid)
            {
                RequestAction newObj = new RequestAction();
                newObj.RequetDataID = obj.RequetDataID;
                newObj.DateOfCreate= DateTime.Now;
                newObj.RequestFromUserID = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newObj.DateOfStartRequest = obj.DateOfStartRequest;
                newObj.DateOfEndtRequest= obj.DateOfEndtRequest;
                newObj.Note = obj.Note;
                newObj.status= 0;
                _reequstRepo.AddObj(newObj);
                return RedirectToAction("Index");
            }
           
            return View();
        }

        public IActionResult OpenRequest(int id)
        {
            var data = _reequstRepo.GetByID(id);
            RequestAction_VM obj = new RequestAction_VM();
            obj.ID = data.ID;
            obj.RequetDataID = data.RequetDataID;
            obj.RequestName = _requestDataRepo.GetByID(data.RequetDataID).RequestName;
            obj.RequestFromUserID = data.RequestFromUserID;
            obj.RequestFromUserName = _userManager.Users.Where(c => c.Id == data.RequestFromUserID)
                .Select(a => a.UserName).FirstOrDefault();
            obj.DateOfCreate = data.DateOfCreate;
            obj.DateOfStartRequest = data.DateOfStartRequest;
            obj.DateOfEndtRequest = data.DateOfEndtRequest;
            obj.Note = data.Note;
            obj.status = data.status;
            obj.UserTakeAction = data.UserTakeAction;
            obj.UserTakeActionName = _userManager.Users.Where(c => c.Id == data.UserTakeAction).Select(a => a.UserName)
                .FirstOrDefault();
            obj.NoteStatus = data.NoteStatus;
            return View(obj);

        }
        [HttpPost]
        public IActionResult AcceptRequest(RequestAction_VM obj)
        {
            
                RequestAction newObj = new RequestAction();
                newObj.ID = obj.ID;
                newObj.NoteStatus = obj.NoteStatus;
                newObj.UserTakeAction = obj.UserTakeAction;
                _reequstRepo.UpdatToAccept(newObj);
                return RedirectToAction("Index");
          

          
        }

        [HttpPost]
        public IActionResult RejectRequest(RequestAction_VM obj)
        {
            
                RequestAction newObj = new RequestAction();
                newObj.ID = obj.ID;
                newObj.NoteStatus = obj.NoteStatus;
                newObj.UserTakeAction = obj.UserTakeAction;
                _reequstRepo.UpdatToReject(newObj);
                return RedirectToAction("Index");
         
           
        }




    }
}
