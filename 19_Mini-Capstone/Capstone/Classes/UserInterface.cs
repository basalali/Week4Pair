using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // All instance of Console.ReadLine and Console.WriteLine should be in this class.

        private Catering catering = new Catering();

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();
                done = true;
            }
            // StockInventory(); Within this method, read inventory txt and add to data (all items should be at 50)

            PrintInitialMenu();

            string initialSelection = Console.ReadLine();
            string orderSelection = Console.ReadLine();
            while (initialSelection != "3")
                {
                switch (initialSelection)
                {
                    case "1":
                        DisplayCateringItems();
                        break;
                    case "2":
                        Order();
                        OrderSelection(orderSelection);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        break;
                }
            }           
        }
        private void PrintInitialMenu()
        {
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Display Catering Items");
            Console.WriteLine("2 - Order");
            Console.WriteLine("3 - Quit");
            return;
        }

        private void DisplayCateringItems()
        {
            while()
            {

            }
        }

        private void Order()
        {
            Console.WriteLine("1 - Add money");
            Console.WriteLine("2 - Select products");
            Console.WriteLine("3 - Complete Transaction");
            return;
        }

        private void OrderSelection(string orderSelection)
        {
            while (orderSelection != "3")
            {
                switch (orderSelection)
                {
                    case "1":
                        //AddMoney();
                        break;
                    case "2":
                        //SelectProducts();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
