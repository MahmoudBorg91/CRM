using System.ComponentModel.DataAnnotations;

namespace GSI_Internal.Models.Api.ExternalLogin;

public class ExternalAuthDto
{
    [Required]
    public string Provider { get; set; }
    [Required]
    public string IdToken { get; set; }
}
