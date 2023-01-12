using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace GSI_Internal.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public string ReturnUrl { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

          
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userId = await _userManager.GetUserIdAsync(user);
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var FirstName=await _userManager.GetUserNameAsync(user);
            var LastName = await  _userManager.Users.Where(x => x.Id == userId).Select(a=>a.LastName).FirstOrDefaultAsync();

            Username = userName;


            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                LastName = LastName,
                FirstName = FirstName,
                
                
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync( string returnUrl= null)
        {
            returnUrl ??= Url.Content(Request.Path.Value);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
               
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            var userId = await _userManager.GetUserIdAsync(user);
            var LastName = await _userManager.Users.Where(x => x.Id == userId).Select(a => a.LastName).FirstOrDefaultAsync();
            if (Input.LastName != LastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

         
            await _signInManager.RefreshSignInAsync(user);
            //StatusMessage = "Your profile has been updated";
           // return RedirectToPage();
         //  returnUrl = ReturnUrl;
           return LocalRedirect(returnUrl);
        }
    }
}
