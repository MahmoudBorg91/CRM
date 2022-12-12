using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.ExternalLogin;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Models.Api.ModelView.AuthViewModel;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;

namespace Halat.BusinessLayer.Services
{
    public class ExternalLoginService : IExternalLoginService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Jwt _jwt;
        private readonly GoogleAuthSettings _googleAuthSettings;
        private readonly FacebookAuthSettings _facebookAuthSettings;


        public ExternalLoginService(UserManager<ApplicationUser> userManager,
            IOptions<Jwt> jwt, IOptions<GoogleAuthSettings> googleAuthSettings, IOptions<FacebookAuthSettings> facebookAuthSettings)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _googleAuthSettings = googleAuthSettings.Value;
            _facebookAuthSettings = facebookAuthSettings.Value;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<AuthModel> ExternalGoogleLogin([FromBody] ExternalAuthDto externalAuth)
        {
            var payload = await VerifyGoogleToken(externalAuth);
            if (payload == null)
                return new AuthModel()
                {
                    Message = "Invalid Google Token",
                    ArMessage = "رمز توکن غير صالح",
                    ErrorCode = (int)Errors.InvalidGoogleToken
                };
            var info = new UserLoginInfo(externalAuth.Provider, payload.Subject, externalAuth.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    payload.Email ??= payload.Name + "@Halat.com";
                    user = new ApplicationUser()
                    {
                        Email = payload.Email,
                        EmailConfirmed = true,
                        FirstName = payload.GivenName,
                        LastName = payload.FamilyName,
                        UserName = payload.Email,
                        PhoneNumberConfirmed = false,
                        Status = true
                    };

                    var createdResult = await _userManager.CreateAsync(user, "123456");
                    if (!createdResult.Succeeded)
                    {
                        return new AuthModel()
                        {
                            Message = "Error in creating user",
                            ArMessage = "خطأ في إنشاء المستخدم",
                            ErrorCode = (int)Errors.ErrorInCreatingUser
                        };
                    }
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            //check for the Locked out account
            if (!user.Status)
                return new AuthModel { Message = "Your account has been suspended!", ArMessage = "حسابك تم إيقافة", ErrorCode = (int)Errors.UserIsBloked };

            var rolesList = _userManager.GetRolesAsync(user).Result.ToList();
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);
            return new AuthModel
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAuthenticated = true,
                Roles = rolesList,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };


        }
        private async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuthDto externalAuth)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleAuthSettings.ClientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(externalAuth.IdToken, settings);
                return payload;
            }
            catch
            {
                //log an exception
                return null;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<AuthModel> FbLogin(FacebookLoginDto loginDto)
        {
            var validatedTokenResult = await ValidateAccessTokenAsync(loginDto.Token);
            if (validatedTokenResult == null || !validatedTokenResult.Data.IsValid)
            {
                return new AuthModel()
                {
                    Message = "Invalid Facebook Token",
                    ArMessage = "رمز توكن غير صالح",
                    ErrorCode = (int)Errors.InvalidFacebookToken
                };
            }

            var userInfo = await GetUserInfoAsync(loginDto.Token);
            if (userInfo == null)
            {
                return new AuthModel()
                {
                    Message = "Invalid Facebook Token",
                    ArMessage = "رمز توكن غير صالح",
                    ErrorCode = (int)Errors.InvalidFacebookToken
                };
            }
            userInfo.Email ??= userInfo.Id + "@Halat.com";

            var user = await _userManager.FindByEmailAsync(userInfo.Email);
            if (user == null)
            {
                var newUser = new ApplicationUser()
                {
                    Email = userInfo.Email,
                    UserName = userInfo.Email,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Status = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var createdResult = await _userManager.CreateAsync(newUser, "123456");
                if (!createdResult.Succeeded)
                {
                    return new AuthModel()
                    {
                        Message = "Error in creating user",
                        ArMessage = "خطأ في إنشاء المستخدم",
                        ErrorCode = (int)Errors.ErrorInCreatingUser
                    };
                }
                await _userManager.AddToRoleAsync(newUser, "User");
                var rolesList = _userManager.GetRolesAsync(newUser).Result.ToList();
                await _userManager.UpdateAsync(newUser);

                var jwtSecurityToken = await CreateJwtToken(newUser);
                return new AuthModel
                {
                    UserId = newUser.Id,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    IsAuthenticated = true,
                    Roles = rolesList,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }
            else
            {
                if (!user.Status)
                    return new AuthModel
                    {
                        Message = "Your account has been suspended!",
                        ArMessage = "حسابك تم إيقافة",
                        ErrorCode = (int)Errors.UserIsBloked
                    };

                var rolesList = _userManager.GetRolesAsync(user).Result.ToList();
                await _userManager.UpdateAsync(user);

                var jwtSecurityToken = await CreateJwtToken(user);
                return new AuthModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsAuthenticated = true,
                    Roles = rolesList,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }

        }
        private async Task<FacebookTokenValidationResultDto> ValidateAccessTokenAsync(string accessToken)
        {

            var formattedUrl = string.Format(_facebookAuthSettings.FacebookTokenValidationUrl, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);
            using var client = new HttpClient();
            var result = await client.GetAsync(formattedUrl);
            if (!result.IsSuccessStatusCode) return null;
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookTokenValidationResultDto>(responseAsString);

        }

        private async Task<FacebookUserInfoResultDto> GetUserInfoAsync(string accessToken)
        {
            var formattedUrl = string.Format(_facebookAuthSettings.FacebookUserInfoUrl, accessToken);
            using var client = new HttpClient();
            var result = await client.GetAsync(formattedUrl);
            if (!result.IsSuccessStatusCode) return null;
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FacebookUserInfoResultDto>(responseAsString);

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        public async Task<AuthModel> LoginWithApple(AppleTokenDto appleToken)
        {
            if (appleToken == null || string.IsNullOrEmpty(appleToken.AccessToken) || string.IsNullOrWhiteSpace(appleToken.AccessToken))
            {
                return new AuthModel()
                {
                    Message = "Invalid Apple Token",
                    ArMessage = "رمز توكن غير صالح",
                    ErrorCode = (int)Errors.InvalidAppleToken
                };

            }

            string email;
            var id = string.Empty;
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken tokenS;
            try
            {
                tokenS = handler.ReadToken(appleToken.AccessToken) as JwtSecurityToken;
                email = tokenS?.Claims.FirstOrDefault(w => w.Type == "email") != null ? tokenS.Claims.FirstOrDefault(w => w.Type == "email")?.Value : null;
                if (tokenS != null) id = tokenS.Claims.FirstOrDefault(w => w.Type == "sub")?.Value;
                if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
                {
                    return new AuthModel()
                    {
                        Message = "Invalid Apple Token",
                        ArMessage = "رمز توكن غير صالح",
                        ErrorCode = (int)Errors.InvalidAppleToken
                    };

                }
            }
            catch
            {
                return new AuthModel()
                {
                    Message = "Invalid Apple Token",
                    ArMessage = "رمز توكن غير صالح",
                    ErrorCode = (int)Errors.InvalidAppleToken
                };

            }

            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                email = id + "@Ayuda.com";
            }


            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                var name = appleToken.Name;

                try
                {
                    if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                    {
                        name = tokenS?.Claims.FirstOrDefault(w => w.Type == "aud") != null ? tokenS.Claims.FirstOrDefault(w => w.Type == "aud")?.Value : null;
                        name = name?.Split('.').FirstOrDefault();
                    }
                }
                catch (Exception)
                {
                    return new AuthModel()
                    {
                        Message = "Invalid Apple Token",
                        ArMessage = "رمز توكن غير صالح",
                        ErrorCode = (int)Errors.InvalidAppleToken
                    };

                }

                var newUser = new ApplicationUser()
                {
                    Email = email,
                    EmailConfirmed = true,
                    FirstName = name,
                    LastName = name,
                    UserName = email,
                    PhoneNumberConfirmed = false,
                    Status = true
                };

                var createdResult = await _userManager.CreateAsync(newUser, "123456");
                if (!createdResult.Succeeded)
                {
                    return new AuthModel()
                    {
                        Message = "Error in creating user",
                        ArMessage = "خطأ في إنشاء المستخدم",
                        ErrorCode = (int)Errors.ErrorInCreatingUser
                    };
                }
                await _userManager.AddToRoleAsync(newUser, "User");
                var rolesList = _userManager.GetRolesAsync(newUser).Result.ToList();
                await _userManager.UpdateAsync(newUser);

                var jwtSecurityToken = await CreateJwtToken(newUser);
                return new AuthModel
                {
                    UserId = newUser.Id,
                    Email = newUser.Email,
                    FirstName = newUser.FirstName,
                    IsAuthenticated = true,
                    Roles = rolesList,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }
            else
            {
                if (!user.Status)
                    return new AuthModel
                    {
                        Message = "Your account has been suspended!",
                        ArMessage = "حسابك تم إيقافة",
                        ErrorCode = (int)Errors.UserIsBloked
                    };

                var rolesList = _userManager.GetRolesAsync(user).Result.ToList();
                await _userManager.UpdateAsync(user);

                var jwtSecurityToken = await CreateJwtToken(user);
                return new AuthModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsAuthenticated = true,
                    Roles = rolesList,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------


        #region create and validate JWT token

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user, int? time = null)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();

            var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                }
                .Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: (time != null) ? DateTime.Now.AddHours((double)time) : DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }


        public string ValidateJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "uid").Value;

                return accountId;
            }
            catch
            {
                return null;
            }
        }

        #endregion create and validate JWT token

        #region Random number and string

        //Generate RandomNo
        public int GenerateRandomNo()
        {
            const int min = 1000;
            const int max = 9999;
            var rdm = new Random();
            return rdm.Next(min, max);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }



        #endregion Random number and string
    }
}