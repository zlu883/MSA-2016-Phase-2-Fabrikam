using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Menu> MenuItemTable;
        private IMobileServiceTable<Bookings> BookingsTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://fabrikamrecords.azurewebsites.net");
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<Menu>> GetMenuItems()
        {
            this.MenuItemTable = this.client.GetTable<Menu>();
            return await this.MenuItemTable.ToListAsync();
        }

        public async Task PostBookings(Bookings b)
        {
            this.BookingsTable = this.client.GetTable<Bookings>();
            await this.BookingsTable.InsertAsync(b);
        }

        public async Task<List<Bookings>> GetBookings()
        {
            this.BookingsTable = this.client.GetTable<Bookings>();
            return await this.BookingsTable.ToListAsync();
        }

        public async Task DeleteBookings(Bookings b)
        {
            this.BookingsTable = this.client.GetTable<Bookings>();
            await this.BookingsTable.DeleteAsync(b);
        }
    }
}
