using System;
using System.Collections.Generic;

namespace Project_OOP_Borromeo
{
    class Program
{
    static void Main()
    {
        List<(int Id, string Name)> categories = CategoryManager.GetCategories();

        List<(string Category, string Item, double Price)> items = ItemManager.GetItems();

        List<(string Category, string Item, double Price, int Quantity)> selectedItems = new List<(string, string, double, int)>();
        bool continueShopping = true;

        while (continueShopping)
        {
                
            CategoryManager.ShowCategories(categories);
            int categoryChoice = InputManager.GetValidInput(1, 4);
			
         /*this method gets quantity for the item in here 
		the value of promp=Enter the quantity: */
            if (categoryChoice == 4)
            {
                /* Ask if the user wants to checkout and this will
					 also display all the current items yu pick
					(the program will end if the user says yes, 
					the value of cshop will be false since the 
					code will proceed if the return value is true)*/
                if (CartManager.DisplayCart(selectedItems))
                {
                    continueShopping = false;
                }
            }
            else
            {
                 /*categories[categoryChoice - 1](index of categories).
					Name is passed as the categoryName parameter. 
					This is the name of the category that the user selected. 
					and also (list)items in the parameter*/
                (string Category, string Item, double Price) selectedItem = ItemManager.SelectItem(categories[categoryChoice - 1].Name, items);
                int quantity = InputManager.GetValidQuantityInput("Enter the quantity: ");
                selectedItems.Add((selectedItem.Category, selectedItem.Item, selectedItem.Price, quantity));
                Console.WriteLine($"{quantity} x {selectedItem.Item} has been added to your cart.\n");

                Console.Write("Do you want to continue shopping? (yes/no): ");
                continueShopping = Console.ReadLine().ToLower() == "yes";
            }
        }

        CartManager.DisplayFinalCart(selectedItems);
    }
}

}

