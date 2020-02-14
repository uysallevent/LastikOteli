using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Lastikoteli.Droid.Helper;
using Lastikoteli.Helper.Abstract;

[assembly: Xamarin.Forms.Dependency(typeof(ToastHelper))]
namespace Lastikoteli.Droid.Helper
{
    public class ToastHelper : IToastService
    {
        public void ToastMessage(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, Html.FromHtml("<font color='#d10000' ><b>" + message + "</b></font>"), ToastLength.Long);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Show();
        }
    }
}