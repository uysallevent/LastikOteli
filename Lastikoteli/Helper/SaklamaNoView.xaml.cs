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
            if (!StringFormatControl.IsAllCharNumeric(xfxEntry.Text))
                xfxEntry.Text = xfxEntry.Text.Remove(xfxEntry.Text.Length - 1);

            xfxEntry.Text = xfxEntry.Text.ToUpper();
            SaklamaNoEntryText = xfxEntry.Text;

            MessagingCenter.Send(this, "plakaTemizle");
            MessagingCenter.Subscribe<PlakaView>(this, "saklamaKodTemizle", (s) =>
            {
                xfxEntry.Text = "";
                SaklamaNoEntryText = "";
            });
            MessagingCenter.Subscribe<MusteriNoView>(this, "musteriNoTemizle", (s) =>
            {
                xfxEntry.Text = "";
                SaklamaNoEntryText = "";
            });
        }
    }
}
