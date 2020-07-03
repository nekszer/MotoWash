using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;
using MotoWash.Models;

namespace MotoWash.ViewModels
{
    public class SelectedServiceViewModel : ViewModelBase
    {

        #region Notified Property Model
        /// <summary>
        /// Model
        /// </summary>
        private ServiceModel model;
        public ServiceModel Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged(); }
        }
        #endregion


        #region Notified Property Categories
        /// <summary>
        /// Categories
        /// </summary>
        private ObservableCollection<CategoryModel> categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property Extras
        /// <summary>
        /// Extras
        /// </summary>
        private ObservableCollection<ExtraModel> extras;
        public ObservableCollection<ExtraModel> Extras
        {
            get { return extras; }
            set { extras = value; OnPropertyChanged(); }
        }
        #endregion

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            if (!(data is ServiceModel model))
                return;
            Model = model;

            Categories = new ObservableCollection<CategoryModel>
            {
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán"
                },
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán"
                },
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán"
                }
            };

            Extras = new ObservableCollection<ExtraModel>
            {
                new ExtraModel
                {
                    Id = 1,
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
                    Name = "2do Auto",
                    Price = 599,
                    Selected = false
                },
                new ExtraModel
                {
                    Id = 1,
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
                    Name = "2do Auto",
                    Price = 599,
                    Selected = false
                },
                new ExtraModel
                {
                    Id = 1,
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
                    Name = "2do Auto",
                    Price = 599,
                    Selected = false
                }
            };
        }

    }
}
