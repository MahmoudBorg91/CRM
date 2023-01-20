using System;
using System.Threading.Tasks;
using GSI_Internal.Repositry.TaskRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.TaskDocuments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GSI_Internal.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepo _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITaskDocument_Repo _taskDocumentRepo;
        private readonly IFileHandling _fileHandling;

        public TasksController(ITaskRepo repo, 
            UserManager<ApplicationUser> _userManager,ITaskDocument_Repo taskDocumentRepo ,IFileHandling fileHandling)
        {
            _repo = repo;
            this._userManager = _userManager;
            _taskDocumentRepo = taskDocumentRepo;
            _fileHandling = fileHandling;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = _repo.GetAllAsync().Result.Select(a => new TaskMain_VM()
            {
                ID = a.Id,
                DateOFReceving = a.DateOFReceving,
                DateOfCreating = a.DateOfCreating,
                DueDateOfEndTask = a.DueDateOfEndTask,
                PriorityLevel = a.PriorityLevel,
                Status = a.Status,
                TaskName = a.TaskName,
                TaskNote = a.TaskNote,
                TransferFromUser = a.TransferFromUser,
                TransferToUser = a.TransferToUser,
                UserCreate = a.UserCreate,
            });
            
         
            return View(data);
        }

        public IActionResult Create()
        {
            var users = _userManager.Users
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                .ToList();




            ViewBag.getAlluser = new SelectList(users, "Id", "UserName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(
            TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj= new TaskMain();
                newobj.TaskName = obj.TaskName;
                newobj.DateOfCreating=DateTime.Now;
                newobj.DueDateOfEndTask = obj.DueDateOfEndTask;
                newobj.DateOFReceving = obj.DateOFReceving;
                newobj.TaskNote=obj.TaskNote;
                newobj.UserCreate = _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newobj.Status=0;
                newobj.PriorityLevel = obj.PriorityLevel;
                newobj.TransferFromUser = newobj.UserCreate;
                newobj.TransferToUser=obj.TransferToUser;
                _repo.AddObj(newobj);
                if (obj.DocIform != null)
                {
                   

                    for (int i = 0; i < obj.DocIform.Count; i++)
                    {
                        TaskDocuments_tbl newDoc = new TaskDocuments_tbl();
                        newDoc.TaskID = newobj.Id;
                        newDoc.UploadDate = DateTime.Now;
                        newDoc.UploadByUser = newobj.UserCreate;

                        if (obj.DocIform != null)
                        {

                            var imgUrl = _fileHandling.UploadFile(obj.DocIform[i], "TasksFile");
                            newDoc.fileName = imgUrl.Result;
                        }

                        
                        _taskDocumentRepo.AddObj(newDoc);
                    }
                   
                   
                }
                
              
                return  RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult>  ReceviceTask(int ID)
        {
            TaskMain_VM obj = new TaskMain_VM();
            var data = _repo.GetByIdAsync(ID).Result;
            obj.ID = data.Id;
            obj.TaskName = data.TaskName;
            obj.TaskNote = data.TaskNote;
            obj.DateOFReceving = data.DateOFReceving;
            obj.DateOfCreating = data.DateOfCreating;
            obj.DueDateOfEndTask = data.DueDateOfEndTask;
            obj.UserCreate = data.UserCreate;
            obj.Status = data.Status;
            obj.PriorityLevel = data.PriorityLevel;
            obj.TransferFromUser = data.TransferFromUser;
            obj.TransferToUser = data.TransferToUser;
            obj.TaskDocumentsVm = _taskDocumentRepo.GetAllAsync().Result.Where(d => d.TaskID == ID).Select(a =>
                new TaskDocuments_VM()
                {
                    ID = a.ID,
                    TaskID = a.TaskID,
                    fileName = a.fileName,
                    UploadDate = a.UploadDate,
                    UploadByUser = a.UploadByUser,

                }).ToList();

            return  View(obj);

        }

    }
}
