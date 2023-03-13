using System;
using System.Threading.Tasks;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Models;

namespace TaskLinerClientApp.Auth
{
    public class Authenticator : IAuthenticator
    {
        public IAuthenticationService AuthService { get; }
        public UserWithToken CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;


        public Authenticator(IAuthenticationService AuthService) => 
            this.AuthService = AuthService;


        public void Logout()
        {
            throw new NotImplementedException();
        }


        public async Task<RegistrationResult> Register(UserRegistrationModel registrationModel) => 
            await AuthService.Register(registrationModel);

        public async Task<UserWithToken> Login(UserIdentityModel userIdentity)
        {
            return CurrentUser = await AuthService.Login(userIdentity);
        }
    }
}
