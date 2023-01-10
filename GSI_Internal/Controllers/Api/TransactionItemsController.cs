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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var transactions = await _unitOfWork.transactionItem.FindByQuery(s=>
                    s.SetInMostServices==true && s.IsNotAvailbale==false)
                .Select(s=> new
                {
                    s.ID,
                    TransactionName = (lang == "ar") ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    s.Icon,
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
        [HttpGet("GetTransactionInSubGroups/{id:int:required}")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> GetTransactionInSubGroups([FromHeader] string lang, int id)
        {
            var transactions = await _unitOfWork.transactionItem.FindByQuery(s=>
                    s.SetInMostServices_INSubGroup==true&&s.TransactionGroupID==id && s.IsNotAvailbale==false)
                .Select(s=> new
                {
                    s.ID,
                    TransactionName = (lang == "ar") ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    s.Icon,
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
        [HttpGet("GetTransactionDetails/{id:int:required}")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse>> GetTransactionDetails([FromHeader] string lang, int id)
        {
            var transactions = await _unitOfWork.transactionItem.FindByQuery(s=>
                    s.ID==id && s.IsNotAvailbale==false)
                .Select(s=> new
                {
                    s.ID,
                    TransactionName = (lang == "ar") ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    TransactionDescription = (lang == "ar") ? s.ServicesDecription_Arabic : s.ServicesDecription_English,
                    TransactionTime = (lang == "ar") ? s.Time_Services_Arabic : s.Time_Services_English,
                    TransactionCondition = (lang == "ar") ? s.Services_Conditions_Arabic : s.Services_Conditions_English,
                    s.Icon,
                    s.ServicesPhoto,
                    s.Price,
                    s.GovernmentFees,

                    TransactionGroup= new
                    {
                        s.TransactionGroupID,
                        TransactionGroupName = (lang == "ar") ? s.TransactionGroup.TransactionGroup_NameArabic : s.TransactionGroup.TransactionGroup_NameEnglish,
                        
                    }, 
                    TransactionSubGroup = new
                    {
                        s.TransactionSubGroupID,
                        TransactionSubGroupName = (lang == "ar") ? s.TransactionSubGroup.SubGroupNameArabic : s.TransactionSubGroup.SubGroupNameEnglish,
                        
                    },
                    AssignRequirment = s.AssignRequirmentToItems.Select(a => new
                    {
                        a.ID,
                        RequirmentName = (lang == "ar") ? a.Requirements.RequirementName_Arabic : a.Requirements.RequirementName_English,
                    }),
                    RequirmentsFileAttachment = s.AssignRequirmentToItems.Select(a => new
                    {
                        a.RequirmentID,
                        RequirmentName = (lang == "ar") ? a.Requirements.RequirementName_Arabic : a.Requirements.RequirementName_English,
                    
                    }),


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
