using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Models.Api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Controllers.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class SlideShowController : BaseApiController, IActionFilter
{
    private readonly BaseResponse _baseResponse;
    private readonly IUnitOfWork _unitOfWork;
    private ApplicationUser _user;

    public SlideShowController(IUnitOfWork unitOfWork)
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
    // GET: api/SlideShow
    [HttpGet("GetSlideShow")]
    [AllowAnonymous]
    public async Task<ActionResult<BaseResponse>> GetClientWallets([FromHeader] string lang)
    {
        var slides = await _unitOfWork.SlideShow.FindByQuery(s => s.ShowInMobile == true)
            .Select(c => new
            {
                c.ID,
                Title = lang == "ar" ? c.Title_Arabic : c.Title_English,
                ReSize = lang == "ar" ? c.ReSizeme_Arabic : c.ReSizeme_English,
                c.SlideImage
            }).ToListAsync();

        if (!slides.Any())
        {
            _baseResponse.ErrorCode = (int)Errors. slidestemsNotFound;
            _baseResponse.ErrorMessage = lang != "ar" ? "slides Not Found" : " لا توجد بيانات  ";
            return Ok(_baseResponse);
        }

        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = slides;
        return Ok(_baseResponse);
    }
}