using System;
using System.Collections.Generic;
using System.Text;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;
using MotoWash.Models;
using System.Linq;

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

        #region Notified Property Total
        /// <summary>
        /// Total
        /// </summary>
        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property BtnContinue
        /// <summary>
        /// BtnContinue
        /// </summary>
        private ICommand btncontinue;
        public ICommand BtnContinue
        {
            get { return btncontinue; }
            set { btncontinue = value; OnPropertyChanged(); }
        }
        #endregion

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            if (!(data is ServiceModel model))
                return;
            Model = model;

            BtnContinue = new Command(BtnContinue_Clicked);

            Categories = new ObservableCollection<CategoryModel>
            {
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán",
                    CategorySelected = new Command(CategorySelected_Changed)
                },
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán",
                    CategorySelected = new Command(CategorySelected_Changed)
                },
                new CategoryModel
                {
                    Id = 1,
                    Selected = false,
                    Price = 213,
                    Name = "Sedán",
                    CategorySelected = new Command(CategorySelected_Changed)
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
                    Selected = false,
                    ExtraSelected = new Command(ExtraSelected_Changed)
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
                    Selected = false,
                    ExtraSelected = new Command(ExtraSelected_Changed)
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
                    Selected = false,
                    ExtraSelected = new Command(ExtraSelected_Changed)
                }
            };

            SetTotal();
        }

        private async void BtnContinue_Clicked(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            await Navigation.Navigate(AppRoutes.Schedule, new ScheduleModel
            {
                Total = Total,
                SubTotal = PrecioExtra,
                BaseCost = Model.Price,
                Coupon = "",
                Extras = Extras.Where(e => e.Selected).Select(s => s.Id),
                Categories = Categories.Where(c => c.Selected).Select(s => s.Id),
                ServiceId = Model.Id
            }, LightForms.Services.ReplaceAction.Push);
            IsBusy = false;
        }

        #region Notified Property PrecioExtra
        /// <summary>
        /// 
        /// </summary>
        private double precioextra;
        public double PrecioExtra
        {
            get { return precioextra; }
            set { precioextra = value; OnPropertyChanged(); }
        }
        #endregion

        private double ExtraTotal;
        private void SetExtraTotal(double total)
        {
            ExtraTotal = total;
            PrecioExtra = CategoryTotal + ExtraTotal;
            SetTotal();
        }

        private void SetTotal()
        {
            Total = Model.Price + PrecioExtra;
        }

        private void ExtraSelected_Changed(object obj)
        {
            SetExtraTotal(Extras.Where(e => e.Selected).Sum(e => e.Price));
        }

        private double CategoryTotal;
        private void SetCategoryTotal(double total)
        {
            CategoryTotal = total;
            PrecioExtra = CategoryTotal + ExtraTotal;
            SetTotal();
        }

        private void CategorySelected_Changed(object obj)
        {
            SetCategoryTotal(Categories.Where(c => c.Selected).Sum(c => c.Price));
        }
    }
}
