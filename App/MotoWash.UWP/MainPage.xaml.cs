using FFImageLoading.Forms.Platform;
using LightForms;
using MotoWash.UWP.Services;
using MotoWash.Services;

namespace MotoWash.UWP
{
    public sealed partial class MainPage : IPlatformInitializer
    {
        public MainPage()
        {
            this.InitializeComponent();
            CachedImageRenderer.Init();
            LoadApplication(new MotoWash.App(this));
        }

        public void RegisterTypes(ICrossContainer container)
        {
            container.Register<ILocalNotification, LocalNotificationImplementation>(FetchTarget.Singleton);
        }
    }
}