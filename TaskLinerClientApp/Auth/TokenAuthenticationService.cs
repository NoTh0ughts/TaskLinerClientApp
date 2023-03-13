using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TaskLiner.DB.Entity;
using TaskLiner.DB.Entity.Views;
using TaskLinerClientApp.Models;

namespace TaskLinerClientApp.Auth
{
    public class TokenAuthenticationService : IAuthenticationService
    {
        public UserWithToken IdentityModel { get; set; }
        public string Token { get; private set; }
        public bool IsValidToken => string.IsNullOrEmpty(Token) == false;


        public async Task<UserWithToken> Login(UserIdentityModel userIdentity)
        {
            try
            {
                WebRequest request = WebRequest.Create(
                    $"https://localhost:5001/token?username={userIdentity.Username}&password={userIdentity.Password}");

                request.Credentials = CredentialCache.DefaultCredentials;
                request.Method = "Post";

                WebResponse response = await request.GetResponseAsync();
                string userJson;
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    userJson = responseFromServer;
                }

                response.Close();

                HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:5001",
                    options =>
                    { options.AccessTokenProvider = () => System.Threading.Tasks.Task.FromResult(Token); })
                    .Build();

                return JsonConvert.DeserializeObject<UserWithToken>(userJson);
            }
            catch
            {
                return null;
            }
        }

        public Task<RegistrationResult> Register(UserRegistrationModel registrationModel)
        {
            throw new NotImplementedException();
        }
    }
}
