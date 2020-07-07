using MotoWash.Resources.Images;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace MotoWash.Converters
{
    public class EmbeddedResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imagename = value?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(imagename)) return null;
            return ImageSource.FromResource("MotoWash.Resources.Images." + imagename, typeof(EmbeddedResourceExtension).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}