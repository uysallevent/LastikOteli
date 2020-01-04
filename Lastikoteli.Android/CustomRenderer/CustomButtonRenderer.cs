using System;
using System.ComponentModel;
using System.Runtime.Remoting.Contexts;
using Lastikoteli.CustomControl;
using Lastikoteli.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace Lastikoteli.Droid.CustomRenderer
{
    [Obsolete]
    public class CustomButtonRenderer : ButtonRenderer
    {


        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetAllCaps(false);
            }
        }
    }
}
