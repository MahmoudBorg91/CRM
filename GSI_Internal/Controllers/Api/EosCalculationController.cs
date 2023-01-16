using System.Linq;
using GSI_Internal.Entites;
using GSI_Internal.Models;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace GSI_Internal.Controllers.Api;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class EosCalculationController : BaseApiController, IActionFilter
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BaseResponse _baseResponse;
    private ApplicationUser _user;

    public EosCalculationController(IUnitOfWork unitOfWork)
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

    [HttpPost("EosCalculation")]
    [AllowAnonymous]
    public IActionResult EosCalculation(EosCalcDto obj)
    {
               
        EosCalcView eosCalc = new ()
        {
            JoiningDate = obj.JoiningDate,
            EndingDate = obj.EndingDate,
            BasicSalary = obj.BasicSalary,
            OtherAllowance = obj.OtherAllowance,
            Year = obj.EndingDate.Year - obj.JoiningDate.Year,
            Month = obj.EndingDate.Month -obj.JoiningDate.Month,
            Day = obj.EndingDate.Day -obj.JoiningDate.Day,
            NumberOfUnpaidLeaveDays = obj.NumberOfUnpaidLeaveDays
        };

        eosCalc.ActWorkPerMonth = ((eosCalc.Year * 12) + (eosCalc.Month) + (eosCalc.Day / 30) -
                                   (eosCalc.NumberOfUnpaidLeaveDays / 365.00000));
        eosCalc.TotalSalary = obj.BasicSalary + obj.OtherAllowance;

        eosCalc.EndOfServiceBenefit = eosCalc.ActWorkPerMonth switch
        {
            <= 60 and >= 12 => eosCalc.ActWorkPerMonth / 12 * (obj.BasicSalary * 21 / 30),
            > 60 => 5 * (obj.BasicSalary * 21 / 30) + (eosCalc.ActWorkPerMonth - 60) * obj.BasicSalary / 12,
            < 12 => 0,
            _ => eosCalc.EndOfServiceBenefit
        };

        eosCalc.AccruedVacationDays = eosCalc.ActWorkPerMonth switch
        {
            > 12 => eosCalc.ActWorkPerMonth * 2.5,
            >= 6 and < 12 => eosCalc.ActWorkPerMonth * 2,
            < 6 => 0,
            _ => eosCalc.AccruedVacationDays
        };

        eosCalc.ExhaustedVacationDays = obj.ExhaustedVacationDays;
        eosCalc.remainingVacationDays = eosCalc.AccruedVacationDays - obj.ExhaustedVacationDays;
        eosCalc.AmountDue = (obj.BasicSalary / 30) * eosCalc.remainingVacationDays;

        eosCalc.TotalBenefitsAndVacations = eosCalc.EndOfServiceBenefit + eosCalc.AmountDue;

        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = eosCalc;
        return Ok(_baseResponse);
    }
        
}