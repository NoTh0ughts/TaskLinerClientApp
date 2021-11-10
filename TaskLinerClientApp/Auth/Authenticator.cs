using System;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLinerClientApp.Models;

namespace TaskLinerClientApp.Auth
{
    public class Authenticator : IAuthenticator
    {
        public IAuthenticationService AuthService { get; }
        public User CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;


        public Authenticator(IAuthenticationService AuthService) => 
            this.AuthService = AuthService;


        public void Logout()
        {
            throw new NotImplementedException();
        }


        public async Task<RegistrationResult> Register(UserRegistrationModel registrationModel) => 
            await AuthService.Register(registrationModel);

        public async Task<bool> Login(UserIdentityModel userIdentity) => 
            await AuthService.Login(userIdentity);
    }
}
