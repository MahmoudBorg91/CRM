using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ExternalLogin;

public class FacebookLoginDto
{
    [Required]
    public string Token { get; set; }
}
