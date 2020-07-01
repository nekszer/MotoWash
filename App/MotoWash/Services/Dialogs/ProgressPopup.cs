using Acr.UserDialogs;

namespace MotoWash.Services
{
    public class ProgressPopup : IProgressPopup
    {
        public void Show()
        {
            UserDialogs.Instance.ShowLoading();
        }

        public void Hide()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}