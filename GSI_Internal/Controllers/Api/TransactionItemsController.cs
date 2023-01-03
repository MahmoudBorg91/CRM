using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.DTO.Pagination;
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
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionItemsController : BaseApiController, IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseResponse _baseResponse;
        private ApplicationUser _user;

        public TransactionItemsController(IUnitOfWork unitOfWork)
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
        [HttpGet("GetMostTransactionItems")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> GetMostTransactionItems([FromHeader] string lang)
        {
            var transactions = await _unitOfWork.transactionItem.FindByQuery(s=>s.SetInMostServices==true)
                .Select(s=> new
                {
                    s.ID,
                    TransactionName = (lang == "ar") ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    s.ServicesPhoto,
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
        //---------------------------------------------------------------------------------------------------
        [HttpGet("GetTransactionSubGroups")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> GetTransactionSubGroups([FromHeader] string lang)
        {
            var transactions = await _unitOfWork.transactionItem.FindByQuery(s=>
                    s.SetInMostServices_INSubGroup==true)
                .Select(s=> new
                {
                    s.ID,
                    TransactionName = (lang == "ar") ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    s.ServicesPhoto,
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
