using System;
using System.Collections.Generic;
using System.Text;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;
using MotoWash.Models;
using MotoWash.Services;
using MotoWash.Resources.Images;

namespace MotoWash.ViewModels
{
    public class HomeViewModel : ViewModelBase, LightForms.Services.IMasterDetailPageOptions
    {

        #region Notified Property Servicios
        /// <summary>
        /// Servicios
        /// </summary>
        private ObservableCollection<ServiceModel> servicios;
        public ObservableCollection<ServiceModel> Servicios
        {
            get { return servicios; }
            set { servicios = value; OnPropertyChanged(); }
        }

        public bool IsPresentedAfterNavigation => false;
        #endregion

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);

            Servicios = new ObservableCollection<ServiceModel>
            {
                new ServiceModel
                {
                    Id = 1,
                    Name = "AUTOS",
                    Price = 645,
                    Html = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            </head>
                            <body>
                                <h4 style='color: black;'>AUTOS</h4>
                                <span>Limpieza de interiores</span><br><br>
                                <span>Incluye:</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                            </body>
                            </html>",
                     Image = "Asiento.jpg",
                     Select = new Command<ServiceModel>(SeleccionarServicio_Clicked)
                },
                new ServiceModel
                {
                    Id = 2,
                    Name = "CARROS",
                    Price = 350,
                    Html = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            </head>
                            <body>
                                <h4 style='color: black;'>AUTOS</h4>
                                <span>Limpieza de interiores</span><br><br>
                                <span>Incluye:</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                            </body>
                            </html>",
                     Image = "Colchon.jpg",
                     Select = new Command<ServiceModel>(SeleccionarServicio_Clicked)
                },
                new ServiceModel
                {
                    Id = 3,
                    Name = "CAR",
                    Price = 200,
                    Html = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                            </head>
                            <body>
                                <h4 style='color: black;'>AUTOS</h4>
                                <span>Limpieza de interiores</span><br><br>
                                <span>Incluye:</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <br>
                                <span>-Pre-lavado con cepillo</span><br>
                                <span>-Pre-lavado con cepillo</span><br>
                            </body>
                            </html>",
                     Image = "Sofa.jpg",
                     Select = new Command<ServiceModel>(SeleccionarServicio_Clicked)
                }
            };
        }

        private void SeleccionarServicio_Clicked(ServiceModel obj)
        {
            Navigation.Navigate(AppRoutes.SelectedService, obj, LightForms.Services.ReplaceAction.Push);
        }
    }
}