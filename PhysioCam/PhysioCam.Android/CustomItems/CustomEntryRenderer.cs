using Android.App;
using Android.Content;
using Android.OS;
using PhysioCam.CustomItems;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Content.Res;
using Android.Text;
using Xamarin.Forms;
using PhysioCam.Droid.CustomItems;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace PhysioCam.Droid.CustomItems
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackground(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.White));
            }
        }
    }
}