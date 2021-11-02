using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;

namespace TaskLinerClientApp.Auth
{
    public enum RegistrationResult
    {
        Success,
        EmailAlreadyExists,
        UserNameAlreadyExists
    }

    interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string password);

        Task<User> Login(string username, string password); 
    }
}
