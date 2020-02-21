using System;
using System.Collections.Generic;
using System.Text;

namespace MK_RestaurantMenu
{
    class Menu
    {
        private DateTime creationDate;
        private DateTime updateDate;
        private List<MenuItem> menuItems;
        //private bool newMenu;
        private int id;
        private static int nextMenuId = 0;

        public  Menu()
        {
            id = nextMenuId;
            nextMenuId++;
            menuItems = new List<MenuItem>();
            creationDate = DateTime.Now;
            updateDate = DateTime.Now;
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
        }
        
        // TODO - completed - A way to tell when the menu was last updated
        public DateTime UpdateDate { 
            get
            {
                return updateDate;
            }
        }

        public List<MenuItem> MenuItems
        {
            get
            {
                return menuItems;
            }
            // this creates the menuItems list when the class is instantiated
            set
            {
                menuItems = value;
                updateDate = DateTime.Now;
            }
        }

        public int Id { get
            {
                return id;
            }
        }

        // TODO - completed --- A way to add and remove menu items from the menu
        public void AddMenuItem(MenuItem menuItem)
        {
            menuItems.Add(menuItem);
        }

        // TODO - completed --- A way to add and remove menu items from the menu
        public void RemoveMenuItem(int menuItemId)
        {
            MenuItem menuItem = menuItems.Find(x => x.Id == menuItemId);
            menuItems.Remove(menuItem);
        }

        public bool MenuItemExistsInMenu(int menuItemId)
        {
            return menuItems.Exists(x => x.Id == menuItemId);
        }

        //TODO - COMPLETED - A way to print out both a menu item and an entire menu
        public override string ToString()
        {
            string menuPrintOut = null;

            foreach (MenuItem menuItem in MenuItems)
            {
                menuPrintOut = menuPrintOut + menuItem.ToString() + "\n\n";
            }

            return menuPrintOut;
        }

        //TODO - Completed -A way to determine whether or not two menu items are equal
        public override bool Equals(object obj)
        {
            Menu newMenu = obj as Menu;
            return id == newMenu.id;
        }

        public override int GetHashCode()
        {
            // using the Menu ID as the menu hashcode
            return Id;
        }
    }
}
