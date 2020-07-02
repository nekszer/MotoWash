using LightForms.Validations;
using System;
using System.Linq;

namespace MotoWash.Validations
{
    public class LenghtRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public int Lenght { get; set; }

        public bool Check(T value)
        {
            var str = value?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(str))
                return false;

            return str.Length >= Lenght;
        }
    }
}
