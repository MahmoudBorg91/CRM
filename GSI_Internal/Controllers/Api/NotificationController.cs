using System.Linq;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.DTO.NotificationModel;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.ApiRepositry.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GSI_Internal.Controllers.Api;


public class NotificationController : BaseApiController
{
    private readonly INotificationService _notificationService;
    private readonly BaseResponse _baseResponse;
    private readonly NotificationModel _notificationModel;
    private readonly IUnitOfWork _unitOfWork;

    public NotificationController(IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
        _baseResponse = new BaseResponse();
        _notificationModel = new NotificationModel();
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetNotifications()
    {
        var notifications =  await _unitOfWork.Users.GetAllAsync();
        if (notifications == null)
        {
            _baseResponse.ErrorMessage = "No Notifications";
            _baseResponse.ErrorCode = 404;
            return Ok(_baseResponse);
        }
        _baseResponse.Data = notifications;
        _baseResponse.ErrorCode = 0;
        return Ok(_baseResponse);
    }


    [HttpPost("SendNotification")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> SendNotification(NotificationDto notificationDto, [FromHeader] string lang)
    {
        if (!ModelState.IsValid)
        {
            _baseResponse.ErrorMessage = (lang == "ar") ? "خطأ في البيانات" : "Error in data";
            _baseResponse.ErrorCode = (int)Errors.TheModelIsInvalid;
            _baseResponse.Data = new { message = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
            return BadRequest(_baseResponse);
        }
        var userId = this.User.Claims.First(i => i.Type == "uid").Value; // will give the user's userId
        var result = await _unitOfWork.Users.FindAsync(s => s.Id == userId);
        // var result = await _accountService.getUserInfo(userId);
        if (result == null)
        {
            _baseResponse.ErrorCode = (int)Errors.TheUserNotExistOrDeleted;
            _baseResponse.ErrorMessage = (lang == "ar") ? "المستخدم غير موجود " : "The User Not Exist Or Deleted";
            _baseResponse.Data = null;
            return BadRequest(_baseResponse);
        }

        var notificationsConfirmed = _unitOfWork.NotificationsConfirmed.FindByQuery(s => s.UserId == userId).Select(s => s.Notification).ToList();
        var notifications = (await _unitOfWork.Notifications.GetAllAsync()).ToList();

        result.DeviceToken = notificationDto.Token;
        _unitOfWork.Users.Update(result);
        await _unitOfWork.SaveChangesAsync();

        if (notifications.Count > 0)
        {
            foreach (var notification in notifications.Where(notification => !notificationsConfirmed.Contains(notification)))
            {
                _notificationModel.DeviceId = notificationDto.Token;
                _notificationModel.Title = notification.Title;
                _notificationModel.Body = notification.Body;
                var notificationResult = await _notificationService.SendNotification(_notificationModel);
                if (notificationResult.IsSuccess)
                {
                    await _unitOfWork.NotificationsConfirmed.AddAsync(new NotificationConfirmed() { NotificationId = notification.Id, UserId = userId });
                    await _unitOfWork.SaveChangesAsync();

                }
                else
                {
                    _baseResponse.ErrorCode = (int)Errors.SomeThingWentwrong;
                    _baseResponse.ErrorMessage = (lang == "ar") ? notificationResult.Message + "test" : notificationResult.Message;
                    _baseResponse.Data = null;
                    return BadRequest(_baseResponse);

                }
            }
        }

        _baseResponse.ErrorCode = (int)Errors.Success;
        _baseResponse.ErrorMessage = (lang == "ar") ? "تم الإرسال" : "Sent";
        _baseResponse.Data = null;
        return Ok(_baseResponse);
    }



}
