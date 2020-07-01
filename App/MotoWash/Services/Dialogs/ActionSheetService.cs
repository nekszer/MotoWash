using Acr.UserDialogs;
using System.Threading.Tasks;

namespace MotoWash.Services
{
    public class ActionSheetService : IActionSheetService
    {
        public Task<string> Show(string title, string cancel, params string[] options)
        {
            return UserDialogs.Instance.ActionSheetAsync(title, cancel, null, buttons: options);
        }
    }
}