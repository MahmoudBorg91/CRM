using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace GSI_Internal.Controllers.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ClientWalletsController : BaseApiController, IActionFilter
{
    private readonly BaseResponse _baseResponse;
    private readonly IUnitOfWork _unitOfWork;
    private ApplicationUser _user;

    public ClientWalletsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _baseResponse = new BaseResponse();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var accessToken = Request.Headers[HeaderNames.Authorization];
        if (string.IsNullOrEmpty(accessToken))
            return;
        var userId = User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
        var user = _unitOfWork.Users.FindByQuery(s => s.Id == userId)
            .FirstOrDefault();
        _user = user;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    //---------------------------------------------------------------------------------------------------
    // GET: api/ClientWallets
    [HttpGet("GetClientWallets")]
    public async Task<ActionResult<BaseResponse>> GetClientWallets([FromHeader] string lang)
    {
        var clintWallet = await _unitOfWork.ClientWallet.FindByQuery(s => s.UserId == _user.Id)
            .Select(c => new
            {
                c.Id,
                c.RequireID,
                RequireName = lang == "ar"
                    ? c.Requirements.RequirementName_Arabic
                    : c.Requirements.RequirementName_English,
                c.TheDateFile,
                c.FileName
            }).ToListAsync();

        if (!clintWallet.Any())
        {
            _baseResponse.ErrorCode = (int)Errors.ClintWalletItemsNotFound;
            _baseResponse.ErrorMessage = lang != "ar" ? "clintWallet Not Found" : " لا توجد بيانات  ";
            return Ok(_baseResponse);
        }

        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = clintWallet;
        return Ok(_baseResponse);
    }
}