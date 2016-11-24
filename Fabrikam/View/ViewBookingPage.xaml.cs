using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam.View
{
    public partial class ViewBookingPage : ContentPage
    {
        public ViewBookingPage()
        {
            InitializeComponent();
            Title = "Check your booking";
        }

        async void OnViewBookingButtonClicked(object sender, EventArgs e)
        {
            List<Bookings> bList = await AzureManager.AzureManagerInstance.GetBookings();
            bool found = false;
            if (PhoneEntry.Text != null || PhoneEntry.Text.Equals(""))
            {
                foreach (Bookings booking in bList)
                {
                    if (PhoneEntry.Text.Equals(booking.PhoneNumber))
                    {
                        await DisplayAlert("Your booking", "You have a booking at " + booking.Date + ", " + booking.Time, "OK");
                        found = true;
                        break;
                    }
                }
            }
            if (!found)
            {
                await DisplayAlert("Booking not found", "You do not have a booking.", "OK");
            }
        }
    }
}
