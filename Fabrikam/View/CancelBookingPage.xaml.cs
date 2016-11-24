using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam.View
{
    public partial class CancelBookingPage : ContentPage
    {
        public CancelBookingPage()
        {
            InitializeComponent();
            Title = "Cancel your booking";
        }

        async void OnCancelBookingButtonClicked(object sender, EventArgs e)
        {
            List<Bookings> bList = await AzureManager.AzureManagerInstance.GetBookings();
            bool found = false;
            if (PhoneEntry.Text != null || PhoneEntry.Text.Equals(""))
            {
                foreach (Bookings booking in bList)
                {
                    if (PhoneEntry.Text.Equals(booking.PhoneNumber))
                    {
                        await AzureManager.AzureManagerInstance.DeleteBookings(booking);
                        found = true;
                        break;
                    }
                }
            }
            if (found)
            {
                await DisplayAlert("Booking cancelled", "Your booking has been cancelled.", "OK");
            }
            else
            {
                await DisplayAlert("Booking not found", "You do not have a booking.", "OK");
            }
        }
    }
}
