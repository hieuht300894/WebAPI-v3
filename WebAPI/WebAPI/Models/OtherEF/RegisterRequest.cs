using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.OtherEF
{
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}