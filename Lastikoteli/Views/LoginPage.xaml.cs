﻿using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
using Xamarin.Forms;

namespace Lastikoteli.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = loginViewModel = new LoginViewModel(this.Navigation);
        }
    }
}