using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Helper
{
    public partial class SaklamaNoView : ContentView
    {
        public SaklamaNoView()
        {
            InitializeComponent();
        }

        public string SaklamaNoEntryText
        {
            get { return (string)GetValue(SaklamaNoEntryTextProperty); }
            set { SetValue(SaklamaNoEntryTextProperty, value); }
        }

        public static readonly BindableProperty SaklamaNoEntryTextProperty = BindableProperty.Create(
                                                  propertyName: "SaklamaNoEntryText",
                                                  returnType: typeof(string),
                                                  declaringType: typeof(SaklamaNoView),
                                                  defaultBindingMode: BindingMode.TwoWay);

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var xfxEntry = (XfxEntry)sender;
            SaklamaNoEntryText = xfxEntry.Text;
        }
    }
}
