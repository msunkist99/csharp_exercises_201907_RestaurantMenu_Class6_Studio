using System;
using System.Collections.Generic;

namespace MK_RestaurantMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menuItems = BuildMenuItems();
            Menu menu = new Menu();
            bool exitMenuCreation = false;

            while (exitMenuCreation == false)
            {
                Console.WriteLine("Do you want to\n 1 -- add items to your menu\n 2 -- remove items from your menu\n 3 -- print your menu \n9 -- your menu is complete");
                int response = Int32.Parse( Console.ReadLine());

                if ((response > 3) ||(response < 0))
                {
                    exitMenuCreation = true;
                }
                else if (response == 1)
                {
                    menu = AddToMenu(menu, menuItems);
                }
                else if (response == 2)
                {
                    menu = RemoveFromMenu(menu);
                }
                else
                {
                    Console.WriteLine(menu.ToString());
                }
            }

            if (menu.MenuItems.Count > 0)
            {
                Console.WriteLine($"Menu Create on {menu.CreationDate.ToShortDateString()} and last updated on {menu.UpdateDate.ToShortDateString()}");
                Console.WriteLine(menu.ToString());
            }
            else
            {
                Console.WriteLine("Your menu contains no menu items");
            }

            Console.ReadLine();
        }

        public static List<MenuItem> BuildMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            MenuItem menuItem;

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.MainCourse,
                Description = "with cheese and fries",
                Name = "Burger",
                Price = 8.99
            };
            menuItems.Add(menuItem);

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.MainCourse,
                Description = "with mashed potatoes and gravy",
                Name = "Meatloaf",
                Price = 9.99
            };
            menuItems.Add(menuItem);

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.Appetizer,
                Description = "with cheese, beans, and jalepeno peppers",
                Name = "Nachos",
                Price = 5.99
            };
            menuItems.Add(menuItem);

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.Appetizer,
                Description = "hot and spicy",
                Name = "Chicken Wings",
                Price = 4.99
            };
            menuItems.Add(menuItem);

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.Dessert,
                Description = "ultimate chocolate",
                Name = "Cake",
                Price = 4.99
            };
            menuItems.Add(menuItem);

            menuItem = new MenuItem()
            {
                CategoryName = MenuItem.Category.Dessert,
                Description = "chocolate, vanilla, and strawberry",
                Name = "Ice Cream",
                Price = 2.99
            };
            menuItems.Add(menuItem);

            return menuItems;
        }

        public static Menu AddToMenu (Menu menu, List<MenuItem> menuItems)
        {
            foreach (MenuItem menuItem in menuItems)
            {
                Console.WriteLine(menuItem.ToString());
            }

            Console.WriteLine("Enter the ID of the menu item to add to your menu");

            int response = Int32.Parse(Console.ReadLine());

            if (response < menuItems.Count)
            {
                if (menu.MenuItemExistsInMenu(response)== false)
                {
                    menu.AddMenuItem(menuItems[response]);
                }
                else
                {
                    Console.WriteLine("That item already exists in your menu");
                }
            }

            return menu;
        }

        public static Menu RemoveFromMenu(Menu menu)
        {
            Console.WriteLine(menu.ToString());
            Console.WriteLine("Enter the ID of the menu item to remove from your menu");

            int response = Int32.Parse(Console.ReadLine());

            menu.RemoveMenuItem(response);

            return menu;
        }

        public static void PrintMenu (Menu menu)
        {
            menu.ToString();
        }
    }
}
