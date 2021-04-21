using PhysioCam.CustomItems;
using PhysioCam.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace PhysioCam.iOS.Renderers
{
    class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer()
        {
            UIKeyboard.Notifications.ObserveWillShow((sender, args) =>
            {
                if (Element != null)
                {
                    Element.Margin = new Thickness(0, 0, 0, args.FrameEnd.Height); //push the entry up to keyboard height when keyboard is activated
                }
            });

            UIKeyboard.Notifications.ObserveWillHide((sender, args) =>
            {
                if (Element != null)
                {
                    Element.Margin = new Thickness(0); //set the margins to zero when keyboard is dismissed
                }
            });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 10;
                Control.TextColor = UIColor.Black;
            }
        }
    }
}
