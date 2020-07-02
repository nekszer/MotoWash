using System;
using System.Collections.Generic;
using System.Text;
using LightForms;
using LightForms.Commands;
using System.Collections.ObjectModel;
using LightForms.Validations;
using MotoWash.Validations;
using LightForms.Attributes;
using MotoWash.Services;

namespace MotoWash.ViewModels
{
    public class SignUpViewModel : ViewModelBase
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


        #region Validatable Property Nombre
        private ValidatableObject<string> nombre = new ValidatableObject<string>
        {
            IsValid = false,
            Validations = new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>
                {
                    ValidationMessage = "Ingresa tu nombre completo"
                }
            }
        };
        public ValidatableObject<string> Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(); }
        }
        #endregion

        #region Validatable Property Telefono
        private ValidatableObject<string> telefono = new ValidatableObject<string>
        {
            IsValid = false,
            Validations = new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>
                {
                    ValidationMessage = "Ingresa tu número de teléfono"
                }
            }
        };
        public ValidatableObject<string> Telefono
        {
            get => telefono;
            set { telefono = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property BtnSignIn
        /// <summary>
        /// BtnSignIn
        /// </summary>
        private ICommand btnsignin;
        public ICommand BtnSignUp
        {
            get { return btnsignin; }
            set { btnsignin = value; OnPropertyChanged(); }
        }
        #endregion

        #region Notified Property TerminosCondicionesCheck
        /// <summary>
        /// TerminosCondicionesCheck
        /// </summary>
        private bool terminosCondicionesCheck;
        public bool TerminosCondicionesCheck
        {
            get { return terminosCondicionesCheck; }
            set { terminosCondicionesCheck = value; OnPropertyChanged(); }
        }
        #endregion

        [Injectable]
        public IAuthenticationService AuthenticationService { get; set; }

        [Injectable]
        public IToastPopup ToastPopup { get; set; }

        public override void Appearing(string route, object data)
        {
            base.Appearing(route, data);
            BtnSignUp = new Command(SignUn_Clicked, IsFormValid);
            Correo.ValueChanged += Form_ValueChanged;
            Contraseña.ValueChanged += Form_ValueChanged;
            Telefono.ValueChanged += Form_ValueChanged;
            Nombre.ValueChanged += Form_ValueChanged;
        }

        private void Form_ValueChanged(object sender, bool e) => BtnSignUp?.RaiseCanExecuteChanged();

        private bool IsFormValid(object arg) => Correo.IsValid && Contraseña.IsValid && Nombre.IsValid && Telefono.IsValid;

        private async void SignUn_Clicked(object obj)
        {
            if (!TerminosCondicionesCheck)
            {
                ToastPopup.Show("Debes aceptar los términos y condiciones del servicio");
                return;
            }

            if (IsBusy) return;
            IsBusy = true;
            var status = await AuthenticationService.SignUp(Nombre.Value, Telefono.Value, Correo.Value, Contraseña.Value);
            if (status)
                ToastPopup.Show("Registro completo");
            else
                ToastPopup.Show("No podemos registrarte, revisa tus datos e intenta de nuevo");
            IsBusy = false;
        }

    }
}