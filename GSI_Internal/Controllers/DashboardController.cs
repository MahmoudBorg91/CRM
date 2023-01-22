using GSI_Internal.Contants;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GSI_Internal.Repositry.TaskRepo;
using Hangfire;
using Microsoft.AspNetCore.SignalR;
using GSI_Internal.Repositry.RequestActionRepo;

namespace GSI_Internal.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DashboardController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHubContext<SignalrServer> _signalrHub;
        private readonly ITaskRepo _taskRepo;
        private readonly IReequstRepo _reequstRepo;

        public DashboardController(UserManager<ApplicationUser> userManager, IHubContext<SignalrServer> signalrHub , ITaskRepo taskRepo, IReequstRepo reequstRepo)
        {

            _userManager = userManager;
            _signalrHub = signalrHub;
            _taskRepo = taskRepo;
            _reequstRepo = reequstRepo;
        }
      [Authorize(Permissions.Dashboard_Permissions.View)]
        //  [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            Dashbourd_VM DashboardVM = new Dashbourd_VM();
            DashboardVM.NumberOfAllTasks = _taskRepo.GetAllAsync().Count();
            DashboardVM.NumberOfNewTask = _taskRepo.GetAllAsync().Count(a => a.Status == 0);
            DashboardVM.NumberOfUnderProcessing = _taskRepo.GetAllAsync().Count(a => a.Status == 1);
            DashboardVM.NumberOfReturnProcessing = _taskRepo.GetAllAsync().Count(a => a.Status == 2);
            DashboardVM.NumberOfUnderFinish= _taskRepo.GetAllAsync().Count(a => a.Status == 3);
            DashboardVM.NumberOfArchiveRequest = _taskRepo.GetAllAsync().Count(a => a.Status == 4);
            DashboardVM.NewRequest = _reequstRepo.GetAll().Count(a => a.status == 0);
            DashboardVM.RequestAccect = _reequstRepo.GetAll().Count(a => a.status == 1);
            DashboardVM.RequestRegect=_reequstRepo.GetAll().Count(a => a.status == 2);
            DashboardVM.AllRequest = _reequstRepo.GetAll().Count();
            return View(DashboardVM);
        }

   















    }

}
