using System.Linq;
using System.Security.Claims;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Repositry.RequestActionRepo;
using GSI_Internal.Repositry.RequestData_Repo;
using GSI_Internal.Repositry.TaskRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IReequstRepo _repo;
        private readonly ITaskRepo _taskRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRequest_DataRepo _requestDataRepo;

        public UserProfileController(IReequstRepo repo , ITaskRepo taskRepo , UserManager<ApplicationUser> userManager , IRequest_DataRepo requestDataRepo)
        {
            _repo = repo;
            _taskRepo = taskRepo;
            _userManager = userManager;
            _requestDataRepo = requestDataRepo;
        }

        public IActionResult Index()
        {
            UserProfile UserProfileVm = new UserProfile()
            {
                TaskMain_VM = _taskRepo.GetAllAsync()
                    .Where(a => a.UserCreate == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a =>
                        new TaskMain_VM()
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
                            TransferFromUser_Name = _userManager.Users.Where(c => c.Id == a.TransferFromUser).Select(a => a.UserName).FirstOrDefault(),
                            TransferToUser = a.TransferToUser,
                            TransferToUser_Name = _userManager.Users.Where(c => c.Id == a.TransferToUser).Select(a => a.UserName).FirstOrDefault(),
                            UserCreate = _userManager.Users.Where(c => c.Id == a.UserCreate).Select(a => a.UserName).FirstOrDefault(),
                        }),
                RequestAction_VM = _repo.GetAll()
                    .Where(a => a.RequestFromUserID == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a =>
                        new RequestAction_VM()
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
                        })

            };
            return View(UserProfileVm);
        }
    }
}
