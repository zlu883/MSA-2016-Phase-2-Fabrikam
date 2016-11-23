using Fabrikam.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam
{
    public partial class FoodHistoryPage : ContentPage
    {
        public FoodHistoryPage()
        {
            InitializeComponent();
            this.Title = "Food History";
            MenuList.ItemsSource = MenuItemGroup.All;
        }
    }
}
