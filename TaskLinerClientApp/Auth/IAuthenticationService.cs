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
    public enum RegistrationResult
    {
        Success,
        EmailAlreadyExists,
        UserNameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(UserRegistrationModel registrationModel);

        Task<UserWithToken> Login(UserIdentityModel userIdentity);
    }
}
