using System.Threading.Tasks;

namespace MotoWash.Services
{
    public interface IAuthenticationService
    {

        Task<bool> SignIn(string email, string password);

        Task<bool> SignUp(string nombre, string telefono, string email, string password);
    }
}
