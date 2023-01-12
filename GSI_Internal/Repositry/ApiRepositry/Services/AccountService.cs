using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.DTO;
using GSI_Internal.Models.Api.Helpers;
using GSI_Internal.Models.Api.ModelView.AuthViewModel;
using GSI_Internal.Repositry.ApiRepositry.Interfaces;
using GSI_Internal.Repositry.ApiRepositry.Repositories;

namespace GSI_Internal.Repositry.ApiRepositry.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly Jwt _jwt;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UserManager<ApplicationUser> userManager, IFileHandling photoHandling,
            RoleManager<ApplicationRole> roleManager,
            IOptions<Jwt> jwt, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _jwt = jwt.Value; 
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? user : null;
        }

        // ------------------------------------------------------------------------------------------------------------------
        public async Task<AuthModel> RegisterAsync(RegisterModelView model, bool isAdmin = false)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel { Message = "this email is already Exist!", ArMessage = "هذا البريد الالكتروني مستخدم من قبل", ErrorCode = (int)Errors.ThisEmailAlreadyExist };

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                NormalizedUserName = model.Email,
                NormalizedEmail = model.Email,
                Status = true,
                UserType = 1,

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Aggregate(string.Empty, (current, error) => current + $"{error.Description},");
                return new AuthModel { Message = errors, ArMessage = errors, ErrorCode = (int)Errors.ErrorWithCreateAccount };
            }
            if (isAdmin)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }


            var newApplicationUser = await _userManager.FindByEmailAsync(model.Email);
            return new AuthModel
            {
                Email = newApplicationUser.Email,
                FirstName = newApplicationUser.FirstName,
                LastName = newApplicationUser.LastName,
                UserType = newApplicationUser.UserType,
                IsAuthenticated = true,
                Roles = new List<string> { "Customer" },
                PhoneVerify = newApplicationUser.PhoneNumberConfirmed,
                Message = "Account successfully created  ",
                ArMessage = "تم أنشاء الحساب بنجاح  "
            };



        }

        //-------------------------------------------------------------------------------------------------------------------------
        public async Task<AuthModel> LoginAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return new AuthModel { Message = "Your phone number is not Exist!", ArMessage = "البريد الالكتروني غير مسجل", ErrorCode = (int)Errors.thisEmailNotExist };
            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                return new AuthModel { Message = "Password is not correct!", ArMessage = "كلمة المرور غير صحيحة", ErrorCode = (int)Errors.TheUsernameOrPasswordIsIncorrect };
            if (!user.Status)
                return new AuthModel { Message = "Your account has been suspended!", ArMessage = "حسابك تم إيقافة", ErrorCode = (int)Errors.UserIsBloked };


            var rolesList = _userManager.GetRolesAsync(user).Result.ToList();
            user.DeviceToken = model.DeviceToken;
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
                UserType = user.UserType,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

        }

        public async Task<bool> Logout(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return false;

            user.DeviceToken = null;
            await _userManager.UpdateAsync(user);
            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------



        public async Task<AuthModel> ChangePasswordAsync(string userId, string password)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return new AuthModel { Message = "User not found!", ArMessage = "المستخدم غير موجود", ErrorCode = (int)Errors.TheUserNotExistOrDeleted };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, password);
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user, 1);
            var rolesList = await _userManager.GetRolesAsync(user);

            var result = new AuthModel
            {
                Message = "The password has been changed successfully",
                ArMessage = "تم تغيير كلمة المرور بنجاح",
                Email = user.Email,
                UserType = user.UserType,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAuthenticated = true,
                Roles = rolesList.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return result;
        }

        public async Task<AuthModel> ChangeOldPasswordAsync(string userId, ChangePassword changePassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return new AuthModel { Message = "User not found!", ArMessage = "المستخدم غير موجود", ErrorCode = (int)Errors.TheUserNotExistOrDeleted };

            var isOldCorrect = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, changePassword.OldPassword);
            if (!isOldCorrect.Equals(PasswordVerificationResult.Success))
                return new AuthModel { Message = "Old password is incorrect!", ArMessage = "كلمة المرور القديمة غير صحيحة", ErrorCode = (int)Errors.OldPasswordIsIncorrect };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePassword.NewPassword);
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user, 1);
            var rolesList = await _userManager.GetRolesAsync(user);

            var result = new AuthModel
            {
                Message = "The password has been changed successfully",
                ArMessage = "تم تغيير كلمة المرور بنجاح",
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
                IsAuthenticated = true,
                Roles = rolesList.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return result;
        }

        //-------------------------------------------------------------------------------------------------------------------------

        public async Task<AuthModel> UpdateProfile(string userId, UpdateUser updateUser)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return new AuthModel { Message = "User not found!", ArMessage = "المستخدم غير موجود" };
            if (await Task.Run(() => _userManager.Users.Any(item => (item.Email == updateUser.Email) && (item.Id != userId))))
                return new AuthModel { Message = "this email is already Exist!", ArMessage = "هذا البريد الالكتروني مستخدم من قبل" };


            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.UserName = updateUser.Email;
            user.NormalizedUserName = updateUser.Email;
            user.Email = updateUser.Email;
            user.NormalizedEmail = updateUser.Email;



            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            var result = new AuthModel
            {
                Message = "The profile has been updated successfully",
                ArMessage = "تم تحديث الملف الشخصي بنجاح",
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAuthenticated = true,
                Roles = rolesList.ToList(),
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return result;
        }

        public async Task<AuthModel> GetUserInfo(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
            {
                return new AuthModel { Message = "User not found!", ArMessage = "المستخدم غير موجود" };
            }

            var rolesList = await _userManager.GetRolesAsync(user);
            var result = new AuthModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsAuthenticated = true,
                Roles = rolesList.ToList(),
                UserType = user.UserType
            };
            return result;
        }

        //------------------------------------------------------------------------------------------------------------
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null)
                return "User not found!";

            if (model.Roles is not { Count: > 0 }) return " Role is empty";
            foreach (var role in model.Roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    return "Invalid Role";
                if (await _userManager.IsInRoleAsync(user, role))
                    return "User already assigned to this role";
            }
            var result = await _userManager.AddToRolesAsync(user, model.Roles);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

        public Task<List<string>> GetRoles()
        {
            return _roleManager.Roles.Select(x => x.Name).ToListAsync();
        }

        //------------------------------------------------------------------------------------------------------------

        public async Task Activate(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.Status = true;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task Suspend(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.Status = false;
                await _userManager.UpdateAsync(user);
            }
        }
        public async Task<AuthModel> AddDeviceToken(DeviceTokenDto model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                return new AuthModel { Message = "User not found!", ArMessage = "المستخدم غير موجود" };

            user.DeviceToken = model.DeviceToken;
            await _userManager.UpdateAsync(user);

            return new AuthModel { Message = "Token added successfully", ArMessage = "تم اضافة الرمز بنجاح", IsAuthenticated = true };

        }


        //------------------------------------------------------------------------------------------------------------

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
                }, out var validatedToken);

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
            int min = 1000;
            int max = 9999;
            Random rdm = new Random();
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
