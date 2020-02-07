using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IsListesiTabbedPage : TabbedPage
    {
        public IsListesiTabbedPage(InfiniteScrollCollection<Randevu> IsEmriList)
        {
            InitializeComponent();
            this.IsListesiPage.IsEmriList(IsEmriList);
        }
    }
}
