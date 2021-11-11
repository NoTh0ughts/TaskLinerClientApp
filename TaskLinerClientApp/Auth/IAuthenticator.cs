using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLinerClientApp.Models;

namespace TaskLinerClientApp.Auth
{
    public interface IAuthenticator
    {
        User CurrentUser { get; }
        bool IsLoggedIn { get; }
        IAuthenticationService AuthService { get; }
        Task<RegistrationResult> Register(UserRegistrationModel registrationModel);
        Task<bool> Login(UserIdentityModel userIdentity);
        void Logout();
    }
}
