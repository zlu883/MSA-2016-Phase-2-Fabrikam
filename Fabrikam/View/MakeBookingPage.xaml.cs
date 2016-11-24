using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Fabrikam.View
{
    public partial class MakeBookingPage : ContentPage
    {
        public MakeBookingPage()
        {
            InitializeComponent();
            Title = "Make a booking";
        }

        async void OnSubmitBookingButtonClicked(object sender, EventArgs e)
        {
            Bookings b = new Bookings();
            b.CustomerName = NameEntry.Text;
            b.PhoneNumber = PhoneEntry.Text;
            if (PersonsPicker.SelectedIndex >= 0)
                b.Persons = PersonsPicker.Items[PersonsPicker.SelectedIndex].ToString();
            b.Time = TimePicker.Time.ToString();
            b.Date = DatePicker.Date.Day.ToString() + "/" + DatePicker.Date.Month.ToString() + "/" + DatePicker.Date.Year.ToString();
            if (b.CustomerName == null || b.PhoneNumber == null || 
                b.CustomerName.Equals("") || b.PhoneNumber.Equals("") || PersonsPicker.SelectedIndex < 0)
            {
                await DisplayAlert("Alert", "Please enter all information", "OK");
            }
            else
            {
                List<Bookings> bList = await AzureManager.AzureManagerInstance.GetBookings();
                bool found = false;
                foreach (Bookings booking in bList)
                {
                    if (PhoneEntry.Text.Equals(booking.PhoneNumber))
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    await DisplayAlert("Booking exists", "You already have a booking.", "OK");
                }
                else
                {
                    await AzureManager.AzureManagerInstance.PostBookings(b);
                    await DisplayAlert("Booking complete", "You have successfully booked a place on " + b.Date + ", " + b.Time, "OK");
                }
            }
        }
    }
}
