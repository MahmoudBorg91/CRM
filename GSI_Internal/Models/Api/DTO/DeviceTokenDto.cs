using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.DTO;

public class DeviceTokenDto
{
    [Required]
    public string DeviceToken { get; set; }
}