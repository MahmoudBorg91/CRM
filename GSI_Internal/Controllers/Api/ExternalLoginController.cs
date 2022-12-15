using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.ExternalLogin;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GSI_Internal.Controllers.Api;

public class ExternalLoginController : BaseApiController
{

  
    private readonly IExternalLoginService _externalLoginService;
    private readonly BaseResponse _baseResponse = new();

    public ExternalLoginController(IExternalLoginService externalLoginService)
    {
        _externalLoginService = externalLoginService;
        
    }

    //-------------------------------------------------------------------------------------------- Role Api 
    [HttpPost("GoogleLogin")]
    public async Task<IActionResult> ExternalLogin([FromBody] ExternalAuthDto model , string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var result = await _externalLoginService.ExternalGoogleLogin(model);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;

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
    //---------------------------------------------------------------------------------------------------------------------------------------

    [HttpPost("FacebookLogin")]
    public async Task<IActionResult> ExternalLoginFacebook([FromBody] FacebookLoginDto model, string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var result = await _externalLoginService.FbLogin(model);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;

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
    //---------------------------------------------------------------------------------------------------------------------------------------

    [HttpPost("AppleLogin")]
    public async Task<IActionResult> ExternalLoginApple([FromBody] AppleTokenDto model, string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return Ok(_baseResponse);
        }
        var result = await _externalLoginService.LoginWithApple(model);
        if (!result.IsAuthenticated)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? result.ArMessage : result.Message;
            _baseResponse.ErrorCode = result.ErrorCode;

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

  
}
