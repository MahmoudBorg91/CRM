using GSI_Internal.Models.Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;



namespace GSI_Internal.Controllers.Api;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
[AllowAnonymous]
public class ErrorsController : ControllerBase
{
    [AllowAnonymous]
    public ActionResult Error(int code)
    {
        var requestFeature = HttpContext.Features.Get<IHttpRequestFeature>();
        bool isApi = requestFeature != null && requestFeature.RawTarget.Contains("/api");
        if (isApi)
        {
            return code switch
            {
                400 => BadRequest(new BaseResponse() { ErrorMessage = "A bad request, you have made", ErrorCode = code }),
                401 => Unauthorized(new BaseResponse() { ErrorMessage = "Authorized, you are not", ErrorCode = code }),
                404 => NotFound(new BaseResponse() { ErrorMessage = "This Endpoint is Not Found", ErrorCode = code }),
                500 => StatusCode(code, new BaseResponse() { ErrorMessage = "Internal Server Error", ErrorCode = code }),
                _ => null
            };
        }
        else
        {
            return Redirect("/ErrorsMvc/Index?code=" + code);

        }



    }
}
