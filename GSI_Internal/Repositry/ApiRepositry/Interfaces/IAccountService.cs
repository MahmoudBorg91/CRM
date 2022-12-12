using System.Collections.Generic;
using System.Threading.Tasks;
using GSI_Internal.Entites;
using GSI_Internal.Models.Api.ModelView.AuthViewModel;


namespace GSI_Internal.Repositry.ApiRepositry.Interfaces
{
    public interface IAccountService
    {
        Task<string> AddRoleAsync(AddRoleModel model);

        Task<List<string>> GetRoles();

        Task<AuthModel> ChangeOldPasswordAsync(string userId, ChangePassword changePassword);

        Task<AuthModel> ChangePasswordAsync(string userId, string password);

        Task<List<ApplicationUser>> GetAllUsers();

        Task<ApplicationUser> GetUserById(string userId);
        Task<ApplicationUser> GetUserByEmail(string email);

        Task<AuthModel> GetUserInfo(string userId);

        Task<AuthModel> LoginAsync(LoginModel model);


        Task<bool> Logout(string userName);

        Task<AuthModel> RegisterAsync(RegisterModelView model, bool isAdmin = false);

        Task<AuthModel> UpdateProfile(string userId, UpdateUser updateUser);


        Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);

        string ValidateJwtToken(string token);

        Task Activate(string userId);

        Task Suspend(string userId);
    }
}
