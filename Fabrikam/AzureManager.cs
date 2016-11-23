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

        private AzureManager()
        {
            this.client = new MobileServiceClient("https://fabrikamrecords.azurewebsites.net");
            this.MenuItemTable = this.client.GetTable<Menu>();
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
            return await this.MenuItemTable.ToListAsync();
        }
    }
}
