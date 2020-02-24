using System;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Behaviors
{
    public class DecimalPointerControlBehavior : Behavior<XfxEntry>
    {
        protected override void OnAttachedTo(XfxEntry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(XfxEntry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (XfxEntry)sender;

            if (entry.Text.Contains("."))
            {
                string entryText = entry.Text;
                entryText = entryText.Replace(".", ",");
                entry.Text = entryText;
            }
        }
    }
}
