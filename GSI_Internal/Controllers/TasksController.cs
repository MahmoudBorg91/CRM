using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GSI_Internal.Repositry.TaskRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.TaskDocuments;
using GSI_Internal.Repositry.TaskProcessingRepo;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITaskProcessingRepo _taskProcessingRepo;

        public TasksController(ITaskRepo repo, 
            UserManager<ApplicationUser> _userManager,ITaskDocument_Repo taskDocumentRepo ,IFileHandling fileHandling, ITaskProcessingRepo taskProcessingRepo)
        {
            _repo = repo;
            this._userManager = _userManager;
            _taskDocumentRepo = taskDocumentRepo;
            _fileHandling = fileHandling;
            _taskProcessingRepo = taskProcessingRepo;
        }
        [Authorize(Permissions.Tasks.View)]
        public  IActionResult Index()
        
        {
            var data = _repo.GetAllAsync().Select(a => new TaskMain_VM()
            {
                ID = a.Id,
                DateOFReceving = a.DateOFReceving,
                DateOfCreating = a.DateOfCreating,
                DueDateOfEndTask = a.DueDateOfEndTask,
                PriorityLevel = a.PriorityLevel,
                PriorityLevelName = _repo.GetPriorityName(a.PriorityLevel),
                Status = a.Status,
                StatusName = _repo.GetStatusName(a.Status),
                UserCreate = a.UserCreate,
                
                TaskName = a.TaskName,
                TaskNote = a.TaskNote,
                TransferFromUser = a.TransferFromUser,
                TransferFromUser_Name = _userManager.Users.Where(c => c.Id == a.TransferFromUser).Select(a => a.UserName).FirstOrDefault(),
                TransferToUser = a.TransferToUser,
                TransferToUser_Name = _userManager.Users.Where(c => c.Id == a.TransferToUser).Select(a => a.UserName).FirstOrDefault(),
                UserCreate_Name = _userManager.Users.Where(c => c.Id == a.UserCreate).Select(a => a.UserName)
                    .FirstOrDefault(),
            });
            
         
            return View(data);
        }
        [Authorize(Permissions.Tasks.OpenTaskManager)]
        public IActionResult OpenTasksByStatus(int status)

        {
            var data = _repo.GetAllAsync().Where(a=>a.Status==status) .Select(a => new TaskMain_VM()
            {
                ID = a.Id,
                DateOFReceving = a.DateOFReceving,
                DateOfCreating = a.DateOfCreating,
                DueDateOfEndTask = a.DueDateOfEndTask,
                PriorityLevel = a.PriorityLevel,
                PriorityLevelName = _repo.GetPriorityName(a.PriorityLevel),
                Status = a.Status,
                StatusName = _repo.GetStatusName(a.Status),
                TaskName = a.TaskName,
                TaskNote = a.TaskNote,
                TransferFromUser = a.TransferFromUser,
                TransferFromUser_Name = _userManager.Users.Where(c => c.Id == a.TransferFromUser).Select(a => a.UserName).FirstOrDefault(),
                TransferToUser = a.TransferToUser,
                TransferToUser_Name = _userManager.Users.Where(c => c.Id == a.TransferToUser).Select(a => a.UserName).FirstOrDefault(),
                UserCreate = a.UserCreate,
                UserCreate_Name = _userManager.Users.Where(c => c.Id == a.UserCreate).Select(a => a.UserName)
                    .FirstOrDefault(),

            });


            return View(data);
        }
        public IActionResult OpenTasksAssign()

        {
            var data = _repo.GetAllAsync().Where(a => a.TransferToUser == User.FindFirstValue(ClaimTypes.NameIdentifier) && a.Status !=4 ).Select(a => new TaskMain_VM()
            {
                ID = a.Id,
                DateOFReceving = a.DateOFReceving,
                DateOfCreating = a.DateOfCreating,
                DueDateOfEndTask = a.DueDateOfEndTask,
                PriorityLevel = a.PriorityLevel,
                PriorityLevelName = _repo.GetPriorityName(a.PriorityLevel),
                Status = a.Status,
                StatusName = _repo.GetStatusName(a.Status),
                TaskName = a.TaskName,
                TaskNote = a.TaskNote,
                TransferFromUser = a.TransferFromUser,
                TransferFromUser_Name = _userManager.Users.Where(c => c.Id == a.TransferFromUser).Select(a => a.UserName).FirstOrDefault(),
                TransferToUser = a.TransferToUser,
                TransferToUser_Name = _userManager.Users.Where(c => c.Id == a.TransferToUser).Select(a => a.UserName).FirstOrDefault(),
                UserCreate = a.UserCreate,
                UserCreate_Name = _userManager.Users.Where(c => c.Id == a.UserCreate).Select(a => a.UserName)
                    .FirstOrDefault(),

            });


            return View(data);
        }

        public IActionResult OpenTasksDeilays()

        {
            var data = _repo.GetAllAsync().Where(a => (DateTime.Now.DayOfYear - a.DueDateOfEndTask.DayOfYear) >0  && a.Status != 4).Select(a => new TaskMain_VM()
            {
                ID = a.Id,
                DateOFReceving = a.DateOFReceving,
                DateOfCreating = a.DateOfCreating,
                DueDateOfEndTask = a.DueDateOfEndTask,
                PriorityLevel = a.PriorityLevel,
                PriorityLevelName = _repo.GetPriorityName(a.PriorityLevel),
                Status = a.Status,
                StatusName = _repo.GetStatusName(a.Status),
                TaskName = a.TaskName,
                TaskNote = a.TaskNote,
                TransferFromUser = a.TransferFromUser,
                TransferFromUser_Name = _userManager.Users.Where(c => c.Id == a.TransferFromUser).Select(a => a.UserName).FirstOrDefault(),
                TransferToUser = a.TransferToUser,
                TransferToUser_Name = _userManager.Users.Where(c => c.Id == a.TransferToUser).Select(a => a.UserName).FirstOrDefault(),
                UserCreate = a.UserCreate,
                UserCreate_Name = _userManager.Users.Where(c => c.Id == a.UserCreate).Select(a => a.UserName)
                    .FirstOrDefault(),

            });


            return View(data);
        }
        [Authorize(Permissions.Tasks.CreateTask)]
        public IActionResult Create()
        {
           
            var users = _userManager.Users
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                .ToList();




            ViewBag.getAlluser = new SelectList(users, "Id", "UserName");
            return View();
        }
        [Authorize(Permissions.Tasks.CreateTask)]
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
                
              
                return  RedirectToAction("Index","Dashboard");
            }

            return View();
        }
        [Authorize(Permissions.Tasks.OpenTask)]
        [HttpGet]
        public  IActionResult OpenTask(int Id)
        {
            var users = _userManager.Users
                .Select(user => new UserViewModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Roles = _userManager.GetRolesAsync(user).Result })
                .ToList();
            ViewBag.getAlluser = new SelectList(users, "Id", "UserName");
            /////////
            TaskMain_VM obj = new TaskMain_VM();
            var data = _repo.GetByIdAsync(Id);
            obj.ID = data.Id;
            obj.TaskName = data.TaskName;
            obj.TaskNote = data.TaskNote;
            obj.DateOFReceving = data.DateOFReceving;
            obj.DateOfCreating = data.DateOfCreating;
            obj.DueDateOfEndTask = data.DueDateOfEndTask;
            obj.NumberOfDays=obj.DueDateOfEndTask.Day - obj.DateOFReceving.Day;
            obj.UserCreate = data.UserCreate;
            obj.UserCreate_Name = _userManager.Users.Where(c => c.Id == obj.UserCreate).Select(a => a.UserName)
                .FirstOrDefault();
            obj.Status = data.Status;
            obj.PriorityLevel = data.PriorityLevel;
            obj.PriorityLevelName = _repo.GetPriorityName(obj.PriorityLevel);
            obj.TransferFromUser = data.TransferFromUser; 
            obj.TransferFromUser_Name= _userManager.Users.Where(c => c.Id == obj.TransferFromUser).Select(a => a.UserName)
                .FirstOrDefault();
            obj.TransferToUser = data.TransferToUser;
            obj.TransferToUser_Name= _userManager.Users.Where(c => c.Id == obj.TransferToUser).Select(a => a.UserName)
                .FirstOrDefault();
            obj.TaskDocumentsVm = _taskDocumentRepo.GetAllAsync().Where(d => d.TaskID == Id).Select(a =>
                new TaskDocuments_VM()
                {
                    ID = a.ID,
                    TaskID = a.TaskID,
                    fileName = a.fileName,
                    UploadDate = a.UploadDate,
                    UploadByUser = a.UploadByUser,

                }).ToList();
           
                obj.TaskProcessing_Vm = _taskProcessingRepo.GetByTaskCode(Id).Select(a => new TaskProcessing_Vm()
                {

                    ID = a.ID,
                    TaskID = a.TaskID,
                    processDate = a.processDate,
                    UserNote = a.UserNote,
                    UserId = a.UserId,
                    UserName = _userManager.Users.Where(c => c.Id == a.UserId).Select(a => a.UserName)
                        .FirstOrDefault(),
                    FromStatus = a.FromStatus,
                    FromStatusName = _repo.GetStatusName(a.FromStatus),
                    ToStatus = a.ToStatus,
                    ToStatusName = _repo.GetStatusName(a.ToStatus)

                }).ToList();
            
         
            return View(obj);

        }




        [Authorize(Permissions.Tasks.DownloadArchive)]

        public FileResult DownloadFile(string fileName)
        {

            string path = System.IO.Directory.GetCurrentDirectory() + "/wwwroot/" + fileName;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
            //Build the File Path.
        }
        [Authorize(Permissions.Tasks.UnderProcessingTask)]
        [HttpPost]
        public IActionResult UnderProcessing(TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj = new TaskMain();
                newobj.Id = obj.ID;
                newobj.Status = 1;

                if (obj.DocIform != null)
                {


                    for (int i = 0; i < obj.DocIform.Count; i++)
                    {
                        TaskDocuments_tbl newDoc = new TaskDocuments_tbl();
                        newDoc.TaskID = newobj.Id;
                        newDoc.UploadDate = DateTime.Now;
                        newDoc.UploadByUser = _userManager.Users
                            .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                            .FirstOrDefault();

                        if (obj.DocIform != null)
                        {

                            var imgUrl = _fileHandling.UploadFile(obj.DocIform[i], "TasksFile");
                            newDoc.fileName = imgUrl.Result;
                        }


                        _taskDocumentRepo.AddObj(newDoc);
                    }


                }

                _repo.UpdateTaskToUnderProcessing(newobj);





                TasksProcessing newTasksProcessing = new TasksProcessing();
                newTasksProcessing.TaskID = obj.ID;
                newTasksProcessing.FromStatus = obj.Status;
                newTasksProcessing.ToStatus = 1;
                newTasksProcessing.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                newTasksProcessing.processDate = DateTime.Now;
                newTasksProcessing.UserNote = obj.taskProcessingNote;

                _taskProcessingRepo.AddObj(newTasksProcessing);

                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Dashboard");




        }
        [Authorize(Permissions.Tasks.FinishTask)]
        [HttpPost]
        public IActionResult FinishProcessing(TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj = new TaskMain();
                newobj.Id = obj.ID;
                newobj.Status = 3;

                if (obj.DocIform != null)
                {


                    for (int i = 0; i < obj.DocIform.Count; i++)
                    {
                        TaskDocuments_tbl newDoc = new TaskDocuments_tbl();
                        newDoc.TaskID = newobj.Id;
                        newDoc.UploadDate = DateTime.Now;
                        newDoc.UploadByUser = _userManager.Users
                            .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                            .FirstOrDefault();

                        if (obj.DocIform != null)
                        {

                            var imgUrl = _fileHandling.UploadFile(obj.DocIform[i], "TasksFile");
                            newDoc.fileName = imgUrl.Result;
                        }


                        _taskDocumentRepo.AddObj(newDoc);
                    }


                }

                _repo.UpdateTaskToFinish(newobj);





                TasksProcessing newTasksProcessing = new TasksProcessing();
                newTasksProcessing.TaskID = obj.ID;
                newTasksProcessing.FromStatus = obj.Status;
                newTasksProcessing.ToStatus = 3;
                newTasksProcessing.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                newTasksProcessing.processDate = DateTime.Now;
                newTasksProcessing.UserNote = obj.taskProcessingNote;

                _taskProcessingRepo.AddObj(newTasksProcessing);

                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Dashboard");




        }
        [Authorize(Permissions.Tasks.ArchiveTask)]
        [HttpPost]
        public IActionResult ArchiveProcessing(TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj = new TaskMain();
                newobj.Id = obj.ID;
                newobj.Status = 4;

                if (obj.DocIform != null)
                {


                    for (int i = 0; i < obj.DocIform.Count; i++)
                    {
                        TaskDocuments_tbl newDoc = new TaskDocuments_tbl();
                        newDoc.TaskID = newobj.Id;
                        newDoc.UploadDate = DateTime.Now;
                        newDoc.UploadByUser = _userManager.Users
                            .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                            .FirstOrDefault();

                        if (obj.DocIform != null)
                        {

                            var imgUrl = _fileHandling.UploadFile(obj.DocIform[i], "TasksFile");
                            newDoc.fileName = imgUrl.Result;
                        }


                        _taskDocumentRepo.AddObj(newDoc);
                    }


                }

                _repo.UpdateTaskToArchive(newobj);





                TasksProcessing newTasksProcessing = new TasksProcessing();
                newTasksProcessing.TaskID = obj.ID;
                newTasksProcessing.FromStatus = obj.Status;
                newTasksProcessing.ToStatus = 4;
                newTasksProcessing.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                newTasksProcessing.processDate = DateTime.Now;
                newTasksProcessing.UserNote = obj.taskProcessingNote;

                _taskProcessingRepo.AddObj(newTasksProcessing);

                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Dashboard");




        }
        [Authorize(Permissions.Tasks.ReturnTask)]
        [HttpPost]
        public IActionResult ReturnProcessing(TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj = new TaskMain();
                newobj.Id = obj.ID;
                newobj.Status = 2;
                newobj.TransferFromUser= _userManager.Users
                    .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                    .FirstOrDefault();
                newobj.TransferToUser = obj.TransferToUser;

                if (obj.DocIform != null)
                {


                    for (int i = 0; i < obj.DocIform.Count; i++)
                    {
                        TaskDocuments_tbl newDoc = new TaskDocuments_tbl();
                        newDoc.TaskID = newobj.Id;
                        newDoc.UploadDate = DateTime.Now;
                        newDoc.UploadByUser = _userManager.Users
                            .Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => a.Id)
                            .FirstOrDefault();

                        if (obj.DocIform != null)
                        {

                            var imgUrl = _fileHandling.UploadFile(obj.DocIform[i], "TasksFile");
                            newDoc.fileName = imgUrl.Result;
                        }


                        _taskDocumentRepo.AddObj(newDoc);
                    }


                }

                _repo.UpdateTaskToReturn(newobj);





                TasksProcessing newTasksProcessing = new TasksProcessing();
                newTasksProcessing.TaskID = obj.ID;
                newTasksProcessing.FromStatus = obj.Status;
                newTasksProcessing.ToStatus = 2;
                newTasksProcessing.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                newTasksProcessing.processDate = DateTime.Now;
                newTasksProcessing.UserNote = obj.taskProcessingNote;

                _taskProcessingRepo.AddObj(newTasksProcessing);

                return RedirectToAction("Index", "Dashboard");
            }

            return RedirectToAction("Index", "Dashboard");




        }

    }
}
