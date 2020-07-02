using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotoWash.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        public IBaseUrl BaseUrl { get; set; }

        public AuthenticationService(IBaseUrl baseurl)
        {
            BaseUrl = baseurl;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            await Task.Delay(2000);
            return email == "demo@gmail.com" && password == "12345678";
        }

        public Task<bool> SignUp(string nombre, string telefono, string email, string password)
        {
            return Task.Run(() => true);
        }
    }
}
