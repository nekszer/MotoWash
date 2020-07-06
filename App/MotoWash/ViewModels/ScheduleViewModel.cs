using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using LightForms;
using LightForms.Commands;
using LightForms.Validations;
using MotoWash.Models;
using MotoWash.Services;

namespace MotoWash.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {

        #region Notified Property ServiceDate
        /// <summary>
        /// ServiceDate
        /// </summary>
        private DateTime servicedate;
        public DateTime ServiceDate
        {
            get { return servicedate; }
            set { servicedate = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property DateSelected
        /// <summary>
        /// DateSelected
        /// </summary>
        private ICommand dateSelected;
        public ICommand DateSelected
        {
            get { return dateSelected; }
            set { dateSelected = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property MaximumDate
        /// <summary>
        /// MaximumDate
        /// </summary>
        private DateTime? maximumdate;
        public DateTime? MaximumDate
        {
            get { return maximumdate; }
            set { maximumdate = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property MinimumDate
        /// <summary>
        /// MinimumDate
        /// </summary>
        private DateTime minimumdate;
        public DateTime MinimumDate
        {
            get { return minimumdate; }
            set { minimumdate = value; OnPropertyChanged(); }
        }
        #endregion


        #region Notified Property StartHours
        /// <summary>
        /// StartHours
        /// </summary>
        private ObservableCollection<TimeSpan> hours;
        public ObservableCollection<TimeSpan> Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property Hour
        /// <summary>
        /// Hour
        /// </summary>
        private TimeSpan? hour;
        public TimeSpan? Hour
        {
            get { return hour; }
            set { hour = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property SelectedHour
        /// <summary>
        /// SelectedHour
        /// </summary>
        private ICommand selectedhour;
        public ICommand SelectedHour
        {
            get { return selectedhour; }
            set { selectedhour = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property BtnScheduleService
        /// <summary>
        /// BtnScheduleService
        /// </summary>
        private ICommand btnScheduleService;
        public ICommand BtnScheduleService
        {
            get { return btnScheduleService; }
            set { btnScheduleService = value; OnPropertyChanged(); }
        }
        #endregion

        private ScheduleModel Model { get; set; }

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            if (!(data is ScheduleModel model)) return;
            Model = model;
            var list = new List<TimeSpan>{
                new TimeSpan(13,0,0),
                new TimeSpan(16,0,0),
                new TimeSpan(20,0,0),
                new TimeSpan(22,0,0)
            };
            Hours = new ObservableCollection<TimeSpan>(list.Where(h => h > DateTime.Now.TimeOfDay));
            DateSelected = new Command(DateSelected_Changed);
            MinimumDate = DateTime.Now.AddDays(0);
            MaximumDate = DateTime.Now.AddMonths(6);
            ServiceDate = DateTime.Now;
            SelectedHour = new Command(SelectedHour_Changed);
            BtnScheduleService = new Command(BtnScheduleService_Clicked, BtnScheduleService_IsValid);
        }

        private void DateSelected_Changed(object obj)
        {
            Hours = new ObservableCollection<TimeSpan>(new List<TimeSpan>{
                new TimeSpan(13,0,0),
                new TimeSpan(16,0,0),
                new TimeSpan(20,0,0),
                new TimeSpan(22,0,0)
            });
        }

        private bool BtnScheduleService_IsValid(object arg) => Hour != null;

        private void BtnScheduleService_Clicked(object obj)
        {
            var date = ServiceDate;
            var time = Hour.Value;
            Model.ServiceDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
            System.Diagnostics.Debug.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Model));
        }

        private void SelectedHour_Changed(object obj)
        {
            if (Hour == null) return;
            if(Hour.Value < DateTime.Now.TimeOfDay)
            {
                CrossContainer.Instance.Create<IToastPopup>().Show("La hora que seleccionaste ya ha pasado");
                Hour = null;
            }
            BtnScheduleService?.RaiseCanExecuteChanged();
        }
    }
}