
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Content.Res;
using HIC.Renderers;
using HIC.Droid.Renderers;

[assembly: ExportRenderer(typeof(OutlinedEntry), typeof(OutlinedEntryRenderer))]
namespace HIC.Droid.Renderers
{
    public class OutlinedEntryRenderer : EntryRenderer
    {
        public OutlinedEntry ElementV2 => Element as OutlinedEntry;
        public OutlinedEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                Control.Bottom = 5;

                var pad = (int)Context.ToPixels(10);
                Control.SetPadding(pad, 0, pad, 0);

                int[][] states = new int[][] {
new int[] { -Android.Resource.Attribute.StateFocused}, // enabled
new int[] {Android.Resource.Attribute.StateFocused} // disabled
};

                int[] colors = new int[] { Color.LightGray.ToAndroid(), Color.FromHex("#23408E").ToAndroid() };

                ColorStateList myList = new ColorStateList(states, colors);

                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(10);
                Control.Background = gradientDrawable;
                gradientDrawable.SetStroke(2, myList);
            }
        }
    }
}
