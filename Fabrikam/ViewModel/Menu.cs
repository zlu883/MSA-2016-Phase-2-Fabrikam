using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrikam.ViewModel
{
    class MenuItemGroup : ObservableCollection<Menu>
    {
        public string Title { get; set; }
        private MenuItemGroup(string title)
        {
            Title = title;
        }

        public static IList<MenuItemGroup> All { private set; get; }
        private static MenuItemGroup entrees;
        private static MenuItemGroup mains;
        private static MenuItemGroup desserts;

        static MenuItemGroup()
        {
            List<MenuItemGroup> Groups = new List<MenuItemGroup>();
            entrees = new MenuItemGroup("Entrees");
            mains = new MenuItemGroup("Mains");
            desserts = new MenuItemGroup("Desserts");
            Groups.Add(entrees);
            Groups.Add(mains);
            Groups.Add(desserts);
            GetMenuItems();

            All = Groups; //set the publicly accessible list
        }
        
        async static void GetMenuItems()
        {
            List<Menu> menuItems = await AzureManager.AzureManagerInstance.GetMenuItems();

            foreach (Menu i in menuItems)
            {
                entrees.Add(i);
            }
        } 
    }
}
