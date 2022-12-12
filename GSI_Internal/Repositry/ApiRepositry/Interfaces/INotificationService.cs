
using System.Threading.Tasks;
using GSI_Internal.Models.Api.DTO.NotificationModel;

namespace GSI_Internal.Repositry.ApiRepositry.Interfaces
{
    public interface INotificationService
    {
        Task<ResponseModel> SendNotification(NotificationModel notificationModel);
    }
}
