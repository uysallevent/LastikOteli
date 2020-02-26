﻿using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaViewModel : BaseViewModel
    {

        public YeniSaklamaTabbedPage Page { get; set; }
        public YeniSaklamaMarkaBilgileriViewModel yeniSaklamaMarkaBilgileriViewModel { get; set; }

        public YeniSaklamaViewModel()
        {
            yeniSaklamaMarkaBilgileriViewModel = new YeniSaklamaMarkaBilgileriViewModel();
        }

    }
}
