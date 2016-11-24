using Fabrikam.View;
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
            this.Children.Add(new SummaryPage());
            this.Children.Add(new MenuPage());
            this.Children.Add(new BookingsPage());
        }
    }
}
