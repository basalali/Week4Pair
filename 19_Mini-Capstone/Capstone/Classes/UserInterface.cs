using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        Catering catering = new Catering();

   
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
            string orderSelection = Console.ReadLine();
            while (orderSelection != "3")
            {
                switch (orderSelection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Please insert money.");
                        string incomingMoney = Console.ReadLine();
                        AddMoney(incomingMoney);
                        PrintAddMoneyMenu();
                        AddMoneySelection();
                        break;
                    case "2":
                        Console.WriteLine("Please enter the product identifier code that you wish to purchase");
                        string userInputID = Console.ReadLine();
                        Console.WriteLine("Please enter the number of items you wish to purchase.");
                        int userInputAmount = Console.Read();
                        ShoppingCartUI(userInputID, userInputAmount);
                        PrintShoppingCartMenu();
                        ShoppingCartMenuSelection();
                        //catering.DisplayShoppingCart();                        
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

        private void PrintShoppingCartMenu()
        { 
            Console.WriteLine();
            Console.WriteLine("Your account balance is: $" + catering.accountBalance);
            Console.WriteLine("Contents of your shopping cart:");
            Console.WriteLine(catering.DisplayShoppingCart());
            Console.WriteLine("1 - Add more items to your cart");
            Console.WriteLine("2 - Return to Order Screen");
        }

        private void ShoppingCartMenuSelection()
        {
            string shoppingCartSelection = Console.ReadLine();
            while (shoppingCartSelection != "2")
            {
                switch (shoppingCartSelection)
                {
                    case "1":
                        Console.WriteLine("Please enter the product identifier code that you wish to purchase");
                        string userInputID = Console.ReadLine();
                        Console.WriteLine("Please enter the number of items you wish to purchase.");
                        int userInputAmount = Console.Read();
                        ShoppingCartUI(userInputID, userInputAmount);
                        PrintShoppingCartMenu();
                        ShoppingCartMenuSelection();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
                PrintShoppingCartMenu();
                shoppingCartSelection = Console.ReadLine();
            }
        }

        private void AddMoneySelection()
        {
            string addMoneySelection = Console.ReadLine();
            while (addMoneySelection != "2")
            {
                switch (addMoneySelection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Please insert money.");
                        string incomingMoney = Console.ReadLine();
                        AddMoney(incomingMoney);
                        PrintAddMoneyMenu();
                        AddMoneySelection();
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

        public void ShoppingCartUI(string userInputID, int userInputAmount)
        {

            if (!catering.ProductExists(userInputID, userInputAmount))
            {
                Console.WriteLine("Product does not exist, please make another selection.");
            }
            else if (!catering.ProductAvailable(userInputID, userInputAmount))
            {
                Console.WriteLine("Product is sold out, please make another selection.");
            }
            else if (!catering.SufficientStock(userInputID, userInputAmount))
            {
                Console.WriteLine("Insufficient stock, please make another selection.");
            }
            else
            {
                catering.AddToShoppingCart(userInputID, userInputAmount);

            }

        }
       

        private void AddMoney(string incomingMoney)
        {
            catering.ConvertMoneyToDecimal(incomingMoney);
            while (!catering.ConvertMoneyToDecimal(incomingMoney))
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a numeral (ex: 1, 15, 75.50, etc):");
                incomingMoney = Console.ReadLine();
                catering.ConvertMoneyToDecimal(incomingMoney);
            }

            decimal decimalIncomingMoney = Convert.ToDecimal(incomingMoney);

            catering.IsPositive(decimalIncomingMoney);
            while (!catering.IsPositive(decimalIncomingMoney))
            {
                Console.WriteLine();
                Console.WriteLine("Please enter a positive number:");
                decimalIncomingMoney = Convert.ToDecimal(Console.ReadLine());
            }

            catering.LessThan5000(decimalIncomingMoney);
            while (!catering.LessThan5000(decimalIncomingMoney))
            {
                Console.WriteLine();
                Console.WriteLine("The maximum account balance allowed is $5000.");
                Console.WriteLine("Your current balance is: $" + catering.accountBalance + ".");
                decimalIncomingMoney = Convert.ToDecimal(Console.ReadLine());
            }
            catering.accountBalance += decimalIncomingMoney;

        }
    }
}
