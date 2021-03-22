using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using HIC.Renderers;
using HIC.iOS.Renderers;

[assembly: ExportRenderer(typeof(OutlinedEntry), typeof(OutlinedEntryRenderer))]
namespace HIC.iOS.Renderers
{
    class OutlinedEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromCGColor(Color.Transparent.ToCGColor());
                Control.BorderStyle = UITextBorderStyle.Bezel;
                Control.Layer.CornerRadius = 5;
            }
        }
    }
}