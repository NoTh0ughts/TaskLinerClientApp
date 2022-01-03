using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Models;

namespace TaskLinerClientApp.Auth
{
    public interface IAuthenticator
    {
        UserWithToken CurrentUser { get; }
        bool IsLoggedIn { get; }
        IAuthenticationService AuthService { get; }
        Task<RegistrationResult> Register(UserRegistrationModel registrationModel);
        Task<UserWithToken> Login(UserIdentityModel userIdentity);
        void Logout();
    }
}
