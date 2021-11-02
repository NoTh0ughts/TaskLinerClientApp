using System;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;

namespace TaskLinerClientApp.Auth
{
    class Authenticator : IAuthenticator
    {
        public User CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<RegistrationResult> Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
