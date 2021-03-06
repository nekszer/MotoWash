﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;

namespace MotoWash.ViewModels
{
    public class AboutUsViewModel : ViewModelBase, LightForms.Services.IMasterDetailPageOptions
    {
        public bool IsPresentedAfterNavigation => false;

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
        }

    }
}
