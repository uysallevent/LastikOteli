using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Lastikoteli.Helper
{
    public partial class TarihView : ContentView
    {
        public TarihView()
        {
            InitializeComponent();
        }

        public DateTime Tarih
        {
            get { return (DateTime)GetValue(TarihProperty); }
            set { SetValue(TarihProperty, value); }
        }

        public static readonly BindableProperty TarihProperty = BindableProperty.Create(
                                                  propertyName: "Tarih",
                                                  returnType: typeof(DateTime),
                                                  declaringType: typeof(TarihView),
                                                  defaultBindingMode: BindingMode.TwoWay);

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var date = (DatePicker)sender;
            Tarih = date.Date;
        }
    }
}
