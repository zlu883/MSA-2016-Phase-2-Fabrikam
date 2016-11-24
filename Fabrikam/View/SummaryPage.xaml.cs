using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace Fabrikam.View
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
            this.Title = "About Us";

            getDistance();
        }

        async public void getDistance()
        {
            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            var latitude = position.Latitude;
            var longitude = position.Longitude;
            //List<DistanceObject> distanceObj = new List<DistanceObject>();
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" 
                + latitude + "," + longitude + "&destinations=22+Viaduct+Harbour+Avenue+Auckland&key=AIzaSyAIKNpfWLmzWn8DR72iQJtyiWt6phJCrTs";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                DistanceObject distanceObj = JsonConvert.DeserializeObject<DistanceObject>(content);
                string distance = distanceObj.rows[0].elements[0].distance.text;
                string duration = distanceObj.rows[0].elements[0].duration.text;
                this.DistanceLabel.Text = "You are just " + distance + " and " + duration + " away from us!";

            }
        }
    }
}
