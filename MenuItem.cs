using System;
using System.Collections.Generic;
using System.Text;

namespace MK_RestaurantMenu
{
    class MenuItem
    {
        private double price;
        private string description;
        private string name;
        private DateTime creationDate;

        // ToDo - COMPLETED - make this an enum
        private Category categoryName;
        private int id = 0;
        private static int nextMenuItemId = 0;


        public MenuItem()
        {
            id = nextMenuItemId;
            nextMenuItemId++;

            creationDate = DateTime.Now;
        }

        public double Price
        {
            get
            { return price; }
            set
            {
                if ((value < 1) || (value > 25))
                {

                }
                else
                {
                    price = value;
                }
            }
        }

        public Category CategoryName 
        { 
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public enum Category
        {
            MainCourse,
            Appetizer,
            Dessert
        }

        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
        }

        //TODO - COMPLETED - A way to tell if a menu item is new
        public bool IsNew
        {
            get
            {
                if (creationDate > DateTime.Today.AddMonths(-3))
                {
                    return true;
                }

                return false;
            }
        }

        //TODO - COMPLETED - A way to print out both a menu item and an entire menu
        public override string ToString()
        {
            return $"Menu Item #{Id} is {Name} - {Description}\n" +
                   $"{CategoryName.ToString()} - {price:C}\n" +
                   $"New item -- {IsNew}";;
        }

        public override bool Equals(object obj)
        {
            MenuItem newMenuItem = obj as MenuItem;
            return id == newMenuItem.id;
        }

        public override int GetHashCode()
        {
            // using the MenuItem ID as the menu item hashcode
            return Id;
        }
    }
}
