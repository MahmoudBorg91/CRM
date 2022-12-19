
using System.Collections.Generic;

namespace GSI_Internal.Models.Api.ModelView.AuthViewModel
{
    public class AuthModel
    {

        public bool IsAuthenticated { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PhoneVerify { get; set; }
        public bool Status { get; set; }
        public bool IsUser { get; set; } = false;
        public bool IsAdmin { get; set; } = false;

        public int  UserType { get; set; }

        public string Message { get; set; }
        public string ArMessage { get; set; }
        public int ErrorCode { get; set; }

    }
}
