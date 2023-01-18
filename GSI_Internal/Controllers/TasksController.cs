using System;
using System.Threading.Tasks;
using GSI_Internal.Repositry.TaskRepo;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;


namespace GSI_Internal.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskRepo _repo;

        public TasksController(ITaskRepo repo)
        {
            _repo = repo;
        }
        
        public async Task<IActionResult> Index()
        {
            var data = _repo.GetAllAsync().Result.Select(a => new TaskMain_VM()
            {
                ID = a.ID,
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

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            TaskMain_VM obj)
        {
            if (ModelState.IsValid)
            {
                TaskMain newobj= new TaskMain();
                newobj.TaskName = newobj.TaskName;
                newobj.DateOfCreating=DateTime.Now;
                newobj.DueDateOfEndTask = obj.DueDateOfEndTask;
                newobj.DateOFReceving = obj.DateOFReceving;
                newobj.TaskNote=obj.TaskNote;
                newobj.UserCreate = obj.UserCreate;
                newobj.Status=obj.Status;
                newobj.TransferFromUser=obj.TransferFromUser;
                newobj.TransferToUser=obj.TransferToUser;
                
               await  _repo.AddObj(newobj);
                return  RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult ReceviceTask(TaskMain_VM obj)
        {

            return View();
        }

    }
}
