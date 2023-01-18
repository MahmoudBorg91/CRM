using GSI_Internal.Context;
using GSI_Internal.Models;
using GSI_Internal.Models.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GSI_Internal.Areas.Identity.Pages.Account;
using GSI_Internal.Entites;

using GSI_Internal.Repositry.SlideShowRepo;

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

using AutoMapper;


namespace GSI_Internal.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbContainer db;
        private readonly UserManager<ApplicationUser> userManager;
     
        private readonly ISlideShowRepo _slideshowRepo;
      
        private readonly IMapper _mapper;
     

        public HomeController(ILogger<HomeController> logger, dbContainer db, UserManager<ApplicationUser> userManager
                            
                             , IMapper mapper )
        {
            _logger = logger;
            this.db = db;
            this.userManager = userManager;
           
            _mapper = mapper;
           
        }
      
        public IActionResult Index()
        {

        

            return View();
        }

     

      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
