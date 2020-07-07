using Android.OS;
using Android.Widget;
using MotoWash.Droid.Effects;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MotoWash")]
[assembly: ExportEffect(typeof(LabelJustifyEffect), nameof(LabelJustifyEffect))]
namespace MotoWash.Droid.Effects
{
    public class LabelJustifyEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var textview = Control as TextView;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                    textview.JustificationMode = Android.Text.JustificationMode.InterWord;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex, nameof(LabelJustifyEffect));
            }
        }

        protected override void OnDetached()
        {

        }
    }
}