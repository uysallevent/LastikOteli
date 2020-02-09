using Lastikoteli.Models;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Services.Abstract;
using Lastikoteli.Services.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IAuthService AuthService => DependencyService.Get<IAuthService>();
        public IIsemriService IsEmriService => DependencyService.Get<IIsemriService>();
        protected Page CurrentPage { get; private set; }
        protected virtual void CurrentPageOnAppearing(object sender, EventArgs eventArgs) { }
        protected virtual void CurrentPageOnDisappearing(object sender, EventArgs eventArgs) { }
        public void Initialize(Page page)
        {
            CurrentPage = page;
            CurrentPage.Appearing += CurrentPageOnAppearing;
            CurrentPage.Disappearing += CurrentPageOnDisappearing;
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
