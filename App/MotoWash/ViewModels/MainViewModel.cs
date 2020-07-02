using LightForms.Commands;
using MotoWash.Models;
using System.Collections.Generic;

namespace MotoWash.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        #region Notified Property Routes
        /// <summary>
        /// Routes
        /// </summary>
        private List<MenuRoute> routes;
        public List<MenuRoute> Routes
        {
            get { return routes; }
            set { routes = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property Route
        /// <summary>
        /// Route
        /// </summary>
        private MenuRoute route;
        public MenuRoute Route
        {
            get { return route; }
            set { route = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property GoToRoute
        /// <summary>
        /// GoToRoute
        /// </summary>
        private ICommand gotoroute;
        public ICommand GoToRoute
        {
            get { return gotoroute; }
            set { gotoroute = value; OnPropertyChanged(); }
        }
        #endregion

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);

            GoToRoute = new Command(GoToRoute_Clicked);

            Routes = new List<MenuRoute>
            {
                new MenuRoute
                {
                    Title = "Inicio",
                    Glyph = Controls.Glyph.Home,
                    Route = AppRoutes.Home
                },
                new MenuRoute
                {
                    Title = "¿Quienes somos?",
                    Glyph = Controls.Glyph.QuestionCircle,
                    Route = AppRoutes.AboutUs
                },
                new MenuRoute
                {
                    Title = "Iniciar sesión",
                    Glyph = Controls.Glyph.SignInAlt,
                    Route = AppRoutes.Login
                }
            };
        }

        private void GoToRoute_Clicked(object obj)
        {
            if (Route == null) return;
            Navigation.Navigate(Route.Route, LightForms.Services.ReplaceAction.MasterDetailPage);
        }
    }
}