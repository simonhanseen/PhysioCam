using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using PhysioCam.CustomItems;
using PhysioCam.Droid.CustomItems;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace PhysioCam.Droid.CustomItems
{
    class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //GradientDrawable gd = new GradientDrawable();
                //gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                this.Control.InputType = InputTypes.TextFlagNoSuggestions;
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));
            }
        }
    }
}