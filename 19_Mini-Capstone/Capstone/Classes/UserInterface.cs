using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        public void RunInterface()
        {
            Catering catering = new Catering();
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                catering.accountBalance = 0;
                done = true;
            }            

            PrintInitialMenu();
            string initialSelection = Console.ReadLine();
            while (initialSelection != "3")
            {
                switch (initialSelection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0, -5} {1, -30} {2, -15} {3, -15} {4, -15}", "ID", "Name", "Price", "Type", "Quantity"));
                        Console.Write(catering.DisplaySelectionMenu());                       
                        break;
                    case "2":                       
                        PrintOrderMenu();
                        OrderSelection();
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
                PrintInitialMenu();
                initialSelection = Console.ReadLine();
            }           
        }
        private void PrintInitialMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Display Catering Items");
            Console.WriteLine("2 - Order");
            Console.WriteLine("3 - Quit");
            return;
        }

        private void OrderSelection()
        {
            Catering catering = new Catering();
            string orderSelection = Console.ReadLine();
            while (orderSelection != "3")
            {
                switch (orderSelection)
                {
                    case "1":
                        catering.AddMoney();
                        PrintAddMoneyMenu();
                        AddMoneySelection();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the product identifier code that you wish to purchase");
                        string userInput = Console.ReadLine();
                        catering.ProductExists(userInput);

                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
                PrintOrderMenu();
                orderSelection = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Your change is $" + catering.accountBalance + ". This will be ejected in the form of:");
            Console.WriteLine(catering.ChangeReturned() + "momentarily.");
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            return;
        }

        private void PrintOrderMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Add money");
            Console.WriteLine("2 - Select products");
            Console.WriteLine("3 - Complete Transaction");
            return;
        }

        private void AddMoneySelection()
        {
            Catering catering = new Catering();
            string addMoneySelection = Console.ReadLine();
            while (addMoneySelection != "2")
            {
                switch (addMoneySelection)
                {
                    case "1":
                        catering.AddMoney();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
                PrintAddMoneyMenu();
                addMoneySelection = Console.ReadLine();
            }
        }

        private void PrintAddMoneyMenu()
        {
            Catering catering = new Catering();
            Console.WriteLine();
            Console.WriteLine("Your account balance is: $" + catering.accountBalance);
            Console.WriteLine("1 - Add more money");
            Console.WriteLine("2 - Return to Order Screen");
            return;
        }        
    }
}
