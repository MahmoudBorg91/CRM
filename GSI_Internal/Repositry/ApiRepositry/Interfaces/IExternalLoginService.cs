using System.Threading.Tasks;
using GSI_Internal.Models.Api.ModelView.AuthViewModel;
using Microsoft.AspNetCore.Mvc;
using GSI_Internal.Models.Api.ExternalLogin;

namespace GSI_Internal.Repositry.ApiRepositry.Interfaces;

public interface IExternalLoginService
{
    Task<AuthModel> ExternalGoogleLogin([FromBody] ExternalAuthDto externalAuth);
    Task<AuthModel> FbLogin(FacebookLoginDto loginDto);
    Task<AuthModel> LoginWithApple(AppleTokenDto appleToken);
}
