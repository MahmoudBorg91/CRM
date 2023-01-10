using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace GSI_Internal.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionSubGroupController : BaseApiController, IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseResponse _baseResponse;
        private ApplicationUser _user;

        public TransactionSubGroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _baseResponse = new BaseResponse();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
            if(string.IsNullOrEmpty(accessToken))
                return;
            var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
            var user = _unitOfWork.Users.FindByQuery(criteria: s => s.Id == userId)
                .FirstOrDefault();
            _user = user;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        //---------------------------------------------------------------------------------------------------
        [HttpGet("GetTransactionSubGroup/{id:int:required}")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> GetTransactionSubGroup([FromHeader] string lang, int id)
        {
            var transactions = await _unitOfWork.TransactionSubGroup.FindByQuery(s=>
                     s.TransactionGroupID==id)
                .Select(s=> new
                {
                    s.ID,
                    SubGroupName = (lang == "ar") ? s.SubGroupNameArabic : s.SubGroupNameEnglish,
                    TransactionGroupNames = (lang == "ar") ? s.TransactionGroup.TransactionGroup_NameArabic : s.TransactionGroup.TransactionGroup_NameEnglish,
                    s.TransactionGroupID,
                    Count = s.TransactionItems.Count()
                }).ToListAsync();

            if (!transactions.Any())
            {
                _baseResponse.ErrorCode = (int)Errors.TransactionItemsNotFound;
                _baseResponse.ErrorMessage = (lang != "ar") ? "TransactionItems Not Found" : " لا توجد بيانات  ";
                return Ok(_baseResponse);
            }

            _baseResponse.ErrorCode = 0;
            _baseResponse.Data = transactions;
            return Ok(_baseResponse);

        }
    
    }
}
