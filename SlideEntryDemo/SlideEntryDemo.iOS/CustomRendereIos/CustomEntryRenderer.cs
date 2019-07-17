using System.ComponentModel;
using SlideEntryDemo.CustomRendererCore;
using SlideEntryDemo.iOS.CustomRendereIos;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace SlideEntryDemo.iOS.CustomRendereIos
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;

            //Control.BackgroundColor = UIColor.Clear;
            //Control.Layer.BorderWidth = 0;
            //Control.BorderStyle = UITextBorderStyle.None;
            //Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
            //Control.TextAlignment = UITextAlignment.Left;
        }
    }
}