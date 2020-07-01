using LightForms;
using LightForms.Services;
using MotoWash.Services;
using System.Globalization;

namespace MotoWash
{
    public partial class App : LightFormsApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            InitializeComponent();
            Culture = new CultureInfo("en");
            SetServiceHandler(new ServiceHandler()); // Se usa para acciones en XAML
            CrossContainer.Instance.Create<INotificationHandler>().Init();
            Initialize(AppRoutes.Main);
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnResume()
        {
            base.OnSleep();
        }

        protected override void Routes(IRoutingService routingservice) => new AppRoutes(routingservice);

        protected override async void RegisterTypes(ICrossContainer container) => await new AppDependencies(container).Async();
    }
}
