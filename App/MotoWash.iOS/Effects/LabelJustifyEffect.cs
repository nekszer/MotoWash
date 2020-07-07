using System;
using MotoWash.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("MotoWash")]
[assembly: ExportEffect(typeof(LabelJustifyEffect), nameof(LabelJustifyEffect))]
namespace MotoWash.iOS.Effects
{
    public class LabelJustifyEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var textview = Control as UITextView;
                textview.TextAlignment = UITextAlignment.Justified;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex, nameof(LabelJustifyEffect));
            }
        }

        protected override void OnDetached()
        {

        }
    }
}