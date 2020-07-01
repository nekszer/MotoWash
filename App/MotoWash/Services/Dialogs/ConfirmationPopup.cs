using Acr.UserDialogs;
using System.Threading.Tasks;

namespace MotoWash.Services
{
    public class ConfirmationPopup : IConfirmationPopup
    {
        public async Task<bool> Show(string title, string message, string ok = null, string cancel = null)
        {
            return await UserDialogs.Instance.ConfirmAsync(message, title, ok, cancel);
        }
    }
}