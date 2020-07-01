using LightForms;
using MotoWash.Services;

namespace MotoWash.ViewModels
{
    public class ViewModelBase : LightForms.ViewModels.ViewModelBase
    {
        protected override void ShowProgress()
        {
            base.ShowProgress();
            CrossContainer.Instance.Create<IProgressPopup>().Show();
        }

        protected override void HideProgress()
        {
            base.HideProgress();
            CrossContainer.Instance.Create<IProgressPopup>().Hide();
        }
    }
}