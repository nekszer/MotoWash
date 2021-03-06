﻿using Acr.UserDialogs;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MotoWash.Services
{
    public class ConfirmationPopup : IConfirmationPopup
    {
        public async Task<bool> Show(string title, string message, string ok = null, string cancel = null)
        {
            return await UserDialogs.Instance.ConfirmAsync(message, title, ok, cancel);
        }
    }
}