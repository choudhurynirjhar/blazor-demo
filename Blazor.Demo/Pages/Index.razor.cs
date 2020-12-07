using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Demo.Pages
{
    partial class Index
    {
        [Inject]
        private ILoginProcessor LoginProcessor { get; set; }

        private LoginModel login = new();
        private string errorMessage = string.Empty;

        private bool ValidateEmail()
        {
            return !string.IsNullOrEmpty(login.Email);
        }

        private bool ValidatePassword()
        {
            return !string.IsNullOrEmpty(login.Password);
        }

        private async Task Login()
        {
            if(ValidateEmail() && ValidatePassword())
            {
                if(!LoginProcessor.Login(login.Email, login.Password))
                {
                    errorMessage = "Invalid login";
                }
            }
            else
            {
                errorMessage = "Email/Password Invalid";
            }
        }
    }
}
