﻿using System.Collections.Generic;

namespace GSI_Internal.Models.ViewModel
{
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}