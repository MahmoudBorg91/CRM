using System.Linq;
using System.Security.Claims;
using GSI_Internal.Areas.Identity.Pages.Account.Manage;

using GSI_Internal.Entites;
using GSI_Internal.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GSI_Internal.Controllers
{
    public class ClientProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ClientProfileController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender, ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var data = _userManager.Users.Where(a=>a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a => new IndexModel(_userManager, _signInManager)
            { 
                
             Username = a.UserName,
             LastName = a.LastName,
             FirstName = a.FirstName,
             PhoneNumber = a.PhoneNumber
             
            }).FirstOrDefault();
            return View(data);
        }

        public IActionResult ChangeClientEmail()
        {
            var data = _userManager.Users.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a =>
                new EmailModel(_userManager, _signInManager, _emailSender)
                {
                    
                    Username = a.UserName,
                    Email = a.Email,
                    IsEmailConfirmed = a.EmailConfirmed,
                    
                    
                }).FirstOrDefault();
            return View(data);
        }


        public IActionResult ChangeClientPassword()
        {
            var data = _userManager.Users.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).Select(a =>
                new ChangePasswordModel(_userManager, _signInManager, _logger)).FirstOrDefault();
            return View(data);
        }
    }
}
