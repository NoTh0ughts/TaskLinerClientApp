using TaskLiner.DB.Entity;
using TaskLinerClientApp.Auth;

namespace TaskLinerClientApp
{
    public static class ApplicationService
    {
        public static IAuthenticator Authenticator { get; private set; }
        public static IAuthenticationService AuthenticationService { get; private set; }

        public static void Init()
        {
            //AuthenticationService = new TokenAuthenticationService(identity);
            //Authenticator = new Authenticator(AuthenticationService);
        }
    }

}
