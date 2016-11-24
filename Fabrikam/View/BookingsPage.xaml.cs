using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam.View
{
    public partial class BookingsPage : ContentPage
    {
        public BookingsPage()
        {
            InitializeComponent();
            Title = "Booking Options";
        }

        async void OnMakeBookingButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeBookingPage());
        }

        async void OnCancelBookingButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CancelBookingPage());
        }

        async void OnCheckBookingButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewBookingPage());
        }
    }
}
