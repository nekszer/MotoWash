using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;

namespace MotoWash.ViewModels
{
    public class LoginViewModel : ViewModelBase, LightForms.Services.IMasterDetailPageOptions
    {

        private int selectedViewIndex;
        public int SelectedViewIndex
        {
            get { return selectedViewIndex; }
            set { selectedViewIndex = value; OnPropertyChanged(); }
        }

        public bool IsPresentedAfterNavigation => false;

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            SelectedViewIndex = 0;
        }

    }
}