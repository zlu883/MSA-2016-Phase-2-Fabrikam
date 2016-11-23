using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Title = "Fabrikam";
            this.Children.Add(new FoodHistoryPage());
            this.Children.Add(new AchievementsPage());
            this.Children.Add(new RewardsPage());     
        }
    }
}
