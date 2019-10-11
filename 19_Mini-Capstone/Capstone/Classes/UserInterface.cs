using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {

        private List<CateringItem> items = new List<CateringItem>();       
        static public Catering catering = new Catering();

       CateringItem type = new CateringItem();
       List<CateringItem> result = catering.GetCateringItems();

       int numberOfItems = 0;

        public void RunInterface()
        {
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
                        DisplaySelectionMenu();                       
                        Console.ReadLine();
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
            string orderSelection = Console.ReadLine();
            while (orderSelection != "3")
            {
                switch (orderSelection)
                {
                    case "1":
                        AddMoney();
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

        public void AddMoney()
        {
            Console.WriteLine();
            Console.WriteLine("Please insert money.");

            decimal incomingMoney = 0;
            while (incomingMoney == 0)
                try
                {
                    incomingMoney = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter amount in arabic numerals (ex. 1, 15.50, 3500)");
                    Console.WriteLine(e);
                }

            while (incomingMoney < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a positive number");
                try
                {
                    incomingMoney = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter amount in arabic numerals (ex. 1, 15.50, 3500)");
                    Console.WriteLine(e);
                }
            }

            while (incomingMoney + catering.accountBalance > 5000)
            {
                Console.WriteLine();
                Console.WriteLine("The maximum account balance allowed is $5000. Your account is currently at $" + catering.accountBalance + ".");
                Console.WriteLine("The most you are able to deposit at this time is $" + (5000 - catering.accountBalance) + ". Please enter a valid deposit amount.");
                try
                {
                    incomingMoney = Convert.ToDecimal(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter amount in arabic numerals (ex. 1, 15.50, 3500)");
                    Console.WriteLine(e);
                }
            }
            catering.accountBalance += incomingMoney;
            return;
        }

        private void AddMoneySelection()
        {
            string addMoneySelection = Console.ReadLine();
            while (addMoneySelection != "2")
            {
                switch (addMoneySelection)
                {
                    case "1":
                        AddMoney();
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
            Console.WriteLine();
            Console.WriteLine("Your account balance is: $" + catering.accountBalance);
            Console.WriteLine("1 - Add more money");
            Console.WriteLine("2 - Return to Order Screen");
            return;
        }

        private void DisplaySelectionMenu()
        {          
            if (result != null && result.Count > 0)
            {
                foreach (CateringItem item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Read from file failed");
            }
            Console.WriteLine();
            return;

        }           

        private void ProductSoldOut()
        {
            
            if (type.Quantity == 0 )
            {
                Console.WriteLine();
                Console.WriteLine("This product is sold out.");

            }

            Console.WriteLine();
            return;

        }

        private void InsufficientStock()
        {
           
            if (type.Quantity < numberOfItems)
            {
                Console.WriteLine();
                Console.WriteLine("There is insufficient stock.");

            }

            Console.WriteLine();
            return;

        }




    }
}
