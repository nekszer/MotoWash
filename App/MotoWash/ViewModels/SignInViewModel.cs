using System;
using System.Collections.Generic;
using System.Text;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;
using LightForms.Validations;
using MotoWash.Validations;
using System.Security.Cryptography;
using LightForms.Attributes;
using MotoWash.Services;

namespace MotoWash.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {


        #region Validatable Property Correo
        private ValidatableObject<string> correo = new ValidatableObject<string>
        {
            IsValid = false,
            Validations = new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>
                {
                    ValidationMessage = "Ingresa un correo"
                }
            }
        };
        public ValidatableObject<string> Correo
        {
            get => correo;
            set { correo = value; OnPropertyChanged(); }
        }
        #endregion

        #region Validatable Property Contraseña
        private ValidatableObject<string> contraseña = new ValidatableObject<string>
        {
            IsValid = false,
            Validations = new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>
                {
                    ValidationMessage = "Ingresa una contraseña"
                },
                new LenghtRule<string>
                {
                    ValidationMessage = "El password debe tener al menos 8 dígitos",
                    Lenght = 8
                }
            }
        };
        public ValidatableObject<string> Contraseña
        {
            get => contraseña;
            set { contraseña = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property BtnRecoveryPassword
        /// <summary>
        /// BtnRecoveryPassword
        /// </summary>
        private ICommand btnrecoverypassword;
        public ICommand BtnRecoveryPassword
        {
            get { return btnrecoverypassword; }
            set { btnrecoverypassword = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property BtnSignIn
        /// <summary>
        /// BtnSignIn
        /// </summary>
        private ICommand btnsignin;
        public ICommand BtnSignIn
        {
            get { return btnsignin; }
            set { btnsignin = value; OnPropertyChanged(); }
        }
        #endregion

        [Injectable]
        public IAuthenticationService AuthenticationService { get; set; }

        [Injectable]
        public IToastPopup ToastPopup { get; set; }

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            BtnSignIn = new Command(SignIn_Clicked, IsFormValid);
            BtnRecoveryPassword = new Command(BtnRecoveryPassword_Clicked);
            Correo.ValueChanged += Form_ValueChanged;
            Contraseña.ValueChanged += Form_ValueChanged;
        }

        private void BtnRecoveryPassword_Clicked(object obj)
        {
            ToastPopup.Show("Se ha hecho click en olvide mi contraseña");
        }

        private void Form_ValueChanged(object sender, bool e) => BtnSignIn?.RaiseCanExecuteChanged();

        private bool IsFormValid(object arg) => Correo.IsValid && Contraseña.IsValid;

        private async void SignIn_Clicked(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;
            var status = await AuthenticationService.SignIn(Correo.Value, Contraseña.Value);
            if (status)
                ToastPopup.Show("Login completo");
            else
                ToastPopup.Show("No podemos validar tus datos");
            IsBusy = false;
        }

    }
}
