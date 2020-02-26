using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Behaviors
{
    public class EntryLengthValidatorBehavior : Behavior<XfxEntry>
    {
        public int MaxLength { get; set; }

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

            if (!string.IsNullOrEmpty(entry.Text) && entry.Text.Length > this.MaxLength)
            {
                string entryText = entry.Text;
                entryText = entryText.Remove(entryText.Length - 1);
                entry.Text = entryText;
            }
        }
    }
}
