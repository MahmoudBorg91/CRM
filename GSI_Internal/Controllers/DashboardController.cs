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

using Hangfire;
using Microsoft.AspNetCore.SignalR;

namespace GSI_Internal.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DashboardController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHubContext<SignalrServer> _signalrHub;
        public DashboardController(UserManager<ApplicationUser> userManager, IHubContext<SignalrServer> signalrHub)
        {

            _userManager = userManager;
            _signalrHub = signalrHub;
        }
      [Authorize(Permissions.Dashboard_Permissions.View)]
        //  [ValidateAntiForgeryToken]
        public IActionResult Index()
        {

          
            return View();
        }

   















    }

}
