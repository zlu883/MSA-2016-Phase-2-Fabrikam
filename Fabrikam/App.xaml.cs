using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

using Xamarin.Forms;

namespace Fabrikam
{

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            getGeolocation();
        }

        async public void getGeolocation()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var t = position;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
