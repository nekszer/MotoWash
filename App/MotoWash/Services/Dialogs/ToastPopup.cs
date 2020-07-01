using Acr.UserDialogs;

namespace MotoWash.Services
{
    public class ToastPopup : IToastPopup
    {
        public void Show(string text)
        {
            UserDialogs.Instance.Toast(text);
        }
    }
}