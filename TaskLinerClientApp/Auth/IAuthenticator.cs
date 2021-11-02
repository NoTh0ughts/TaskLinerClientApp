using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;

namespace TaskLinerClientApp.Auth
{
    interface IAuthenticator
    {
        User CurrentUser { get; }

        bool IsLoggedIn { get; }


        Task<RegistrationResult> Register(string email, string password);

        Task<bool> Login(string username, string password);

        void Logout();
    }
}
