using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers.Api;

public class ContactUsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly BaseResponse _baseResponse;



    public ContactUsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _baseResponse = new BaseResponse();
    }
        
    [HttpGet("ContactUs")]
    public async Task<IActionResult> Get([FromHeader] string lang)
    {
        var contactUs = (await _unitOfWork.ContactUs.GetAllAsync()).FirstOrDefault();

        if (contactUs == null)
        {
            _baseResponse.ErrorCode = (int)Errors.ContactUsNotFound;
            _baseResponse.ErrorMessage = (lang!= "ar")?"ContactUs Not Found":" لا توجد بيانات اتصال ";
            return Ok(_baseResponse);
        }
            
        _baseResponse.ErrorCode = 0;
        _baseResponse.Data = new {
            contactUs.Id,
            contactUs.WhatsAppNumber,
            contactUs.PhoneNumber,
            contactUs.Email,
            contactUs.Link,
            contactUs.FaceBookLink,
            contactUs.InstagramLink,
            contactUs.TwitterLink,
            contactUs.YouTubeLink,
            contactUs.LinkedInLink,
            TermsAndConditions = (lang!="ar") ? contactUs.TermsAndConditions:contactUs.TermsAndConditionsAr
        };
        return Ok(_baseResponse);
    }


}