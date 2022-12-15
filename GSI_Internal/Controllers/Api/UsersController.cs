using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Models.Api.ModelView.AuthViewModel;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;


namespace GSI_Internal.Controllers.Api;

public class UsersController : BaseApiController
{

    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IAccountService _accountService;
    private readonly BaseResponse _baseResponse = new();

    public UsersController(IAccountService accountService, RoleManager<ApplicationRole> roleManager)
    {
        _accountService = accountService;
        _roleManager = roleManager;
    }

    //-------------------------------------------------------------------------------------------- Role Api 
    [HttpPost("AddRole")]
    public async Task<ActionResult<BaseResponse>> AddRoles(RoleDto roleDto, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var oldRole = await _roleManager.FindByNameAsync(roleDto.RoleName);
        if (oldRole != null)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "هذا الصلاحية موجودة مسبقا" : "This role is already exist";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }

        var role = await _roleManager.CreateAsync(new ApplicationRole()
        {
            Name = roleDto.RoleName,
            NameAr = roleDto.RoleNameAr,
            Description = roleDto.Description,
            RoleNumber = roleDto.GroupNumber,
        });
        if (role.Succeeded)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "تم اضافة الصلاحية بنجاح" : "Role added successfully";
            _baseResponse.ErrorCode = (int)Errors.Success;
            _baseResponse.Data = null;
            return Ok(_baseResponse);
        }
        else
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = role.Errors.ToString() };
            return Ok(_baseResponse);
        }
    }

    //-------------------------------------------------------------------------------------------- student Register 
    [HttpPost("Register")]
    public async Task<ActionResult<BaseResponse>> RegisterStudent(RegisterModelView model, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var result = await _accountService.RegisterAsync(model);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;

        }
        else
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = (int)Errors.Success;
            _baseResponse.Data = new { result.FirstName,result.LastName, result.Email };
        }
        return Ok(_baseResponse);

    }

    //-------------------------------------------------------------------------------------------- login Api 
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<BaseResponse>> LoginAsync([FromBody] LoginModel model, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var result = await _accountService.LoginAsync(model);

        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorCode = result.ErrorCode;
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.Data = model;
            return Ok(_baseResponse);
        }
        _baseResponse.ErrorCode = 0;
        _baseResponse.ErrorMessage = (lang == "ar") ? "تم تسجيل الدخول" : "Login Successfully";
        _baseResponse.Data = new
        {
            result.Email,
            result.FirstName,
            result.LastName,
            result.Token,
            Role = result.Roles,
        };
        return Ok(_baseResponse);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------
    [HttpPost("AddDeviceToken")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> AddDeviceToken([FromBody] DeviceTokenDto model, string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var userId = this.User.Claims.First(i => i.Type == "uid").Value;
        if (string.IsNullOrEmpty(userId))
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "المستخدم غير موجود" : "User not found";
            _baseResponse.ErrorCode = (int)Errors.TheUserNotExistOrDeleted;
            _baseResponse.Data = null;
            return Ok(_baseResponse);

        }

        var result = await _accountService.AddDeviceToken(model,userId);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;

        }
        _baseResponse.ErrorCode = 0;
        _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
        return Ok(_baseResponse);

    }
    //-------------------------------------------------------------------------------------------- logout Api 
    [HttpPost("logout")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<BaseResponse>> LogoutAsync([FromHeader] string lang)
    {
        //var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
        var userName = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userName
        if (!string.IsNullOrEmpty(userName))
        {
            var result = await _accountService.Logout(userName);
            if (result)
            {
                _baseResponse.ErrorCode = 0;
                _baseResponse.ErrorMessage = (lang == "ar") ? "تم تسجيل الخروج بنجاح " : "Signed out successfully";
                return Ok(_baseResponse);
            }
        }
        _baseResponse.ErrorCode = (int)Errors.TheUserNotExistOrDeleted;
        _baseResponse.ErrorMessage = (lang == "ar") ? "هذا الحساب غير موجود " : "The User Not Exist";
        return Ok(_baseResponse);
    }

    //------------------------------------------------------------------------------------------------ Change Password Api
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut("changeoldPassword")]
    public async Task<ActionResult<BaseResponse>> ChangeOldPasswordAsync([FromBody] ChangePassword changePassword, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId

        var result = await _accountService.ChangeOldPasswordAsync(userId, changePassword);

        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;
            _baseResponse.Data = null;
            return Ok(_baseResponse);
        }

        _baseResponse.ErrorCode = 0;
        _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
        _baseResponse.Data = new
        {
            result.Email,
            result.FirstName,
            result.LastName,
            result.Token,
            Role = result.Roles,
        };
        return Ok(_baseResponse);
    }

    //------------------------------------------------------------------------------------------------ forgot Password Api

    [HttpPut("changeForgotPassword")]
    public async Task<ActionResult<BaseResponse>> ChangePasswordAsync([FromBody] ChangeForgotPassword password, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var user = await _accountService.GetUserByEmail(password.Email);
        if (user == null)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "هذا الحساب غير موجود " : "The User Not Exist";
            _baseResponse.ErrorCode = (int)Errors.TheUserNotExistOrDeleted;
            _baseResponse.Data = null;
            return Ok(_baseResponse);
        }

        var result = await _accountService.ChangePasswordAsync(user.Id, password.Password);

        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;
            return Ok(_baseResponse);
        }

        _baseResponse.ErrorCode = 0;
        _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
        _baseResponse.Data = new
        {
            result.Email,
            result.FirstName,
            result.LastName,
            Role = result.Roles,
            result.Token
        };
        return Ok(_baseResponse);
    }

    //----------------------------------------------------------------------------------------------------- get profile
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("GetUserInfo")]
    public async Task<ActionResult<BaseResponse>> GetUserInfo([FromHeader] string lang)
    {
        var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
        if (string.IsNullOrEmpty(userId))
        {
            _baseResponse.ErrorCode = (int)Errors.TheUserNotExistOrDeleted;
            _baseResponse.ErrorMessage = (lang == "ar") ? "المستخدم غير موجود" : "User not exist";
            _baseResponse.Data = null;
            return Ok(_baseResponse);
        }
        var result = await _accountService.GetUserInfo(userId);

        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;
            _baseResponse.Data = result;
            return Ok(_baseResponse);
        }
        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = new
        {
            result.Email,
            result.FirstName,
            result.LastName,
            Role = result.Roles,
        };
        return Ok(_baseResponse);
    }

    //----------------------------------------------------------------------------------------------------- update user profile
    [HttpPut("UpdateProfile")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<BaseResponse>> Profile(UpdateUser updateUser, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return BadRequest(_baseResponse);
        }
        var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
        var result = await _accountService.UpdateProfile(userId, updateUser);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;
            _baseResponse.Data = updateUser;
            return BadRequest(_baseResponse);
        }
        _baseResponse.ErrorCode = 0;
        _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
        _baseResponse.Data = new
        {
            result.Email,
            result.FirstName,
            result.LastName,
            Role = result.Roles,
        };
        return Ok(_baseResponse);

    }
    //---------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------------------------------------------------

}
