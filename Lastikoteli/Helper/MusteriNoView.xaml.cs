using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Helper
{
    public partial class MusteriNoView : ContentView
    {
        public MusteriNoView()
        {
            InitializeComponent();
        }

        public string MusteriNoEntryText
        {
            get { return (string)GetValue(MusteriNoEntryTextProperty); }
            set { SetValue(MusteriNoEntryTextProperty, value); }
        }

        public static readonly BindableProperty MusteriNoEntryTextProperty = BindableProperty.Create(
                                                  propertyName: "MusteriNoEntryText",
                                                  returnType: typeof(string),
                                                  declaringType: typeof(MusteriNoView),
                                                  defaultBindingMode: BindingMode.TwoWay);

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var xfxEntry = (XfxEntry)sender;
            MusteriNoEntryText = xfxEntry.Text;
        }
    }
}
