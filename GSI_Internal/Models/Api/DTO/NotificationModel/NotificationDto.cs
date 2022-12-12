using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.DTO.NotificationModel
{
    public class NotificationDto
    {
        [Required]
        public string Token { get; set; }
    }
}
