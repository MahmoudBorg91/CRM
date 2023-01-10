using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models;
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
public class TransactionItemsController : BaseApiController, IActionFilter
{
    private readonly BaseResponse _baseResponse;
    private readonly IUnitOfWork _unitOfWork;
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
    [HttpGet("GetMostTransactionItems")]
    [AllowAnonymous]
    public async Task<ActionResult<BaseResponse>> GetMostTransactionItems([FromHeader] string lang)
    {
        var transactions = await _unitOfWork.transactionItem.FindByQuery(s =>
                s.SetInMostServices == true && s.IsNotAvailbale == false)
            .Select(s => new
            {
                s.ID,
                TransactionName = lang == "ar" ? s.TransactionNameArabic : s.TransactionNameEnglish,
                s.Icon,
                s.ServicesPhoto
            }).ToListAsync();

        if (!transactions.Any())
        {
            _baseResponse.ErrorCode = (int)Errors.TransactionItemsNotFound;
            _baseResponse.ErrorMessage = lang != "ar" ? "TransactionItems Not Found" : " لا توجد بيانات  ";
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
        var transactions = await _unitOfWork.transactionItem.FindByQuery(s =>
                s.SetInMostServices_INSubGroup == true && s.TransactionGroupID == id && s.IsNotAvailbale == false)
            .Select(s => new
            {
                s.ID,
                TransactionName = lang == "ar" ? s.TransactionNameArabic : s.TransactionNameEnglish,
                s.Icon,
                s.ServicesPhoto
            }).ToListAsync();

        if (!transactions.Any())
        {
            _baseResponse.ErrorCode = (int)Errors.TransactionItemsNotFound;
            _baseResponse.ErrorMessage = lang != "ar" ? "TransactionItems Not Found" : " لا توجد بيانات  ";
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
        dynamic transaction;
        if (_user == null)
        {
            #region Get Transaction Details

            transaction = await _unitOfWork.transactionItem.FindByQuery(s =>
                    s.ID == id && s.IsNotAvailbale == false)
                .Select(s => new
                {
                    s.ID,
                    TransactionName = lang == "ar" ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    TransactionDescription = lang == "ar" ? s.ServicesDecription_Arabic : s.ServicesDecription_English,
                    TransactionTime = lang == "ar" ? s.Time_Services_Arabic : s.Time_Services_English,
                    TransactionCondition = lang == "ar" ? s.Services_Conditions_Arabic : s.Services_Conditions_English,
                    s.Icon,
                    s.ServicesPhoto,
                    s.Price,
                    s.GovernmentFees,

                    TransactionGroup = new
                    {
                        s.TransactionGroupID,
                        TransactionGroupName = lang == "ar"
                            ? s.TransactionGroup.TransactionGroup_NameArabic
                            : s.TransactionGroup.TransactionGroup_NameEnglish
                    },
                    TransactionSubGroup = new
                    {
                        s.TransactionSubGroupID,
                        TransactionSubGroupName = lang == "ar"
                            ? s.TransactionSubGroup.SubGroupNameArabic
                            : s.TransactionSubGroup.SubGroupNameEnglish
                    },
                    AssignRequirment = s.AssignRequirmentToItems.Select(a => new
                    {
                        a.ID,
                        RequirmentName = lang == "ar"
                            ? a.Requirements.RequirementName_Arabic
                            : a.Requirements.RequirementName_English
                    })
                }).ToListAsync();

            #endregion
        }
        else
        {
            #region Get Transaction Details for user

            transaction = await _unitOfWork.transactionItem.FindByQuery(s =>
                    s.ID == id && s.IsNotAvailbale == false)
                .Select(s => new
                {
                    s.ID,
                    TransactionName = lang == "ar" ? s.TransactionNameArabic : s.TransactionNameEnglish,
                    TransactionDescription = lang == "ar" ? s.ServicesDecription_Arabic : s.ServicesDecription_English,
                    TransactionTime = lang == "ar" ? s.Time_Services_Arabic : s.Time_Services_English,
                    TransactionCondition = lang == "ar" ? s.Services_Conditions_Arabic : s.Services_Conditions_English,
                    s.Icon,
                    s.ServicesPhoto,
                    s.Price,
                    s.GovernmentFees,

                    TransactionGroup = new
                    {
                        s.TransactionGroupID,
                        TransactionGroupName = lang == "ar"
                            ? s.TransactionGroup.TransactionGroup_NameArabic
                            : s.TransactionGroup.TransactionGroup_NameEnglish
                    },
                    TransactionSubGroup = new
                    {
                        s.TransactionSubGroupID,
                        TransactionSubGroupName = lang == "ar"
                            ? s.TransactionSubGroup.SubGroupNameArabic
                            : s.TransactionSubGroup.SubGroupNameEnglish
                    },
                    TransactionRequirment = s.AssignRequirmentToItems.Select(a => new
                    {
                        a.ID,
                        a.RequirmentID,
                        RequirmentName = lang == "ar"
                            ? a.Requirements.RequirementName_Arabic
                            : a.Requirements.RequirementName_English
                    }),
                    TransactionInquiry = s.AssignInquiryToItems.Select(a => new
                    {
                        a.ID,
                        a.InquiryID,
                        InquiryName = lang == "ar"
                            ? a.TransactionItemInquiry.InquiryName_Arabic
                            : a.TransactionItemInquiry.InquiryName_English,
                        InquiryType = a.TransactionItemInquiry.Inquiry_Type
                    }),
                    TransactionSelection = s.AssignSelectionToItems.Select(a => new
                    {
                        a.ID,
                        a.SelectionID,
                        SelectionName = lang == "ar"
                            ? a.TransiactionItem_Selection.SelectionName_Arabic
                            : a.TransiactionItem_Selection.SelectionName_English,
                        a.TransiactionItem_Selection.SelectionGroupID,
                        SelectionGroupName = lang == "ar"
                            ? a.TransiactionItem_Selection.RequestSelection_Group.Selection_GroupName_Arab
                            : a.TransiactionItem_Selection.RequestSelection_Group.Selection_GroupName_English
                    }),
                    ClientWallet = s.AssignRequirmentToItems
                        .SelectMany(w => w.Requirements.ClientWallets
                            .Where(c => c.UserId == _user.Id).Select(c => new ClientWalletVM
                            {
                                Id = c.Id,
                                RequireID = c.RequireID,
                                RequireName = lang == "ar"
                                    ? c.Requirements.RequirementName_Arabic
                                    : c.Requirements.RequirementName_English,
                                TheDateFile = c.TheDateFile,
                                FileName = c.FileName
                            }))
                }).FirstOrDefaultAsync();
            var clientWalletVm = await _unitOfWork.ClientWallet.FindByQuery(a => a.UserId == _user.Id)
                .Select(w => new ClientWalletVM
                {
                    Id = w.Id,
                    RequireID = w.RequireID,
                    RequireName = lang == "ar"
                        ? w.Requirements.RequirementName_Arabic
                        : w.Requirements.RequirementName_English,
                    TheDateFile = w.TheDateFile,
                    FileName = w.FileName
                }).ToListAsync();

            // transaction.ClientWallet = clientWalletVm;

            #endregion
        }


        if (transaction == null)
        {
            _baseResponse.ErrorCode = (int)Errors.TransactionItemsNotFound;
            _baseResponse.ErrorMessage = lang != "ar" ? "TransactionItems Not Found" : " لا توجد بيانات  ";
            return Ok(_baseResponse);
        }

        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = transaction;
        return Ok(_baseResponse);
    }
}