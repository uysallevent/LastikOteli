using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.Helper
{
    public partial class PlakaView : ContentView
    {
        public PlakaView()
        {
            InitializeComponent();
        }

        public string PlakaEntryText
        {
            get { return (string)GetValue(PlakaEntryTextProperty); }
            set { SetValue(PlakaEntryTextProperty, value); }
        }

        public static readonly BindableProperty PlakaEntryTextProperty = BindableProperty.Create(
                                                  propertyName: "PlakaEntryText",
                                                  returnType: typeof(string),
                                                  declaringType: typeof(PlakaView),
                                                  defaultBindingMode: BindingMode.TwoWay);

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var xfxEntry = (XfxEntry)sender;

            xfxEntry.Text = xfxEntry.Text.ToUpper();
            PlakaEntryText = xfxEntry.Text;

            MessagingCenter.Send(this, "saklamaKodTemizle");
            MessagingCenter.Subscribe<SaklamaNoView>(this, "plakaTemizle", (s) =>
            {
                xfxEntry.Text = "";
                PlakaEntryText = "";
            });
            MessagingCenter.Subscribe<MusteriNoView>(this, "musteriNoTemizle", (s) =>
            {
                xfxEntry.Text = "";
                PlakaEntryText = "";
            });
        }
    }
}
