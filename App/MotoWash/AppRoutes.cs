using LightForms.Services;
using MotoWash.Resources.Strings;
using MotoWash.ViewModels;
using MotoWash.Views;

namespace MotoWash
{
    public class AppRoutes
    {

        /// <summary>
        /// Pagina principal de la app
        /// </summary>
        public static string Main { get; } = "/main";

        public static string Login { get; } = "/login";

        public static string Home { get; } = "/home";

        public static string SignIn { get; } = "/signin";

        public static string SignUp { get; } = "/signup";
        public static string AboutUs { get; set; } = "/aboutus";

        /// <summary>
        /// RoutingService
        /// </summary>
        /// <param name="routingservice"></param>
        public AppRoutes(IRoutingService routingservice)
        {
            routingservice.Route<MainPage, MainViewModel>(Main, new RouteInfo
            {
                Title = "Pagina principal",
                Description = "aw dawhd awkdh awkdh wad",
                ExtendedDescription = " hawjdh wajdh wakjd hwajdh jawh djkawhd jkahw djkawhd jwh "
            }, new JsonLocalizationManager("Main.json"));

            routingservice.Route<LoginPage, LoginViewModel>(Login);

            routingservice.Route<HomePage, HomeViewModel>(Home);

            routingservice.Route<SignInView, SignInViewModel>(SignIn);

            routingservice.Route<SignUpView, SignUpViewModel>(SignUp);

            routingservice.Route<AboutUsPage, AboutUsViewModel>(AboutUs);
        }
    }
}