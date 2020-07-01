using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotoWash.Extensions
{
    [ContentProperty(nameof(Source))]
    public class ImageExtension : IMarkupExtension
    {

        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Source)) return null;
            return null;
        }
    }
}