using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class UserInterface
    {
        Catering catering = new Catering();
        FileAccess fileAccess = new FileAccess();

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                catering.AccountBalance = 0;
                done = true;
            }
            PrintInitialMenu();
            InitialSelection();
        }
        public void InitialSelection()
        {
            string initialSelection = Console.ReadLine();
            while (initialSelection != "3")
            {
                switch (initialSelection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0, -5} {1, -30} {2, -15} {3, -15} {4, -15}", "ID", "Name", "Price", "Type", "Quantity"));
                        Console.Write(catering.DisplaySelectionMenu());
                        PrintInitialMenu();
                        InitialSelection();
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
            }
            Environment.Exit(0);
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

            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

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
                        fileAccess.AddMoneyTracker(incomingMoney); // records everytime someone inserts money! method is in fileaccess.
                        AddMoneySelection();
                      
                            break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Please enter the product identifier code that you wish to purchase");
                        string userInputID = Console.ReadLine();
                        userInputID = userInputID.ToUpper();
                        Console.WriteLine();
                        Console.WriteLine("Please enter the number of items you wish to purchase.");
                        int userInputAmount = Convert.ToInt32(Console.ReadLine());
                        ShoppingCartUI(userInputID, userInputAmount);
                        catering.RemoveFromItem(userInputID, userInputAmount);
                        PrintShoppingCartMenu();
                        ShoppingCartMenuSelection();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
                PrintOrderMenu();
                OrderSelection();
            }
            Console.WriteLine();
            CalculateChangeToReturn();
            Console.WriteLine("Press enter to continue to a new transaction.");
            Console.ReadLine();

            PrintInitialMenu();
            InitialSelection();
        }

        private void PrintOrderMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Add money");
            Console.WriteLine("2 - Select products to purchase");
            Console.WriteLine("3 - Complete transaction");
            return;
        }

        private void PrintShoppingCartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Current contents of your shopping cart:");
            Console.WriteLine();
            Console.WriteLine(String.Format("{0, -5} {1, -30} {2, -15} {3, -15} {4, -15}", "ID", "Name", "Price", "Type", "Quantity"));
            Console.WriteLine(catering.DisplayShoppingCart());
            Console.WriteLine("Your current total is: $" + catering.ShoppingCartTotal);
            Console.WriteLine("Your account balance is: $" + (catering.AccountBalance));
            Console.WriteLine();
            Console.WriteLine("1 - Display catering items");
            Console.WriteLine("2 - Add more items to your shopping cart");
            Console.WriteLine("3 - Return to Order Screen");
        }

        private void ShoppingCartMenuSelection()
        {
            CateringItem CI = new CateringItem(); // used to get access to name property.
            string shoppingCartSelection = Console.ReadLine();
            while (shoppingCartSelection != "3")
            {
                switch (shoppingCartSelection)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine(String.Format("{0, -5} {1, -30} {2, -15} {3, -15} {4, -15}", "ID", "Name", "Price", "Type", "Quantity"));
                        Console.Write(catering.DisplaySelectionMenu());
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Please enter the product identifier code that you wish to purchase");
                        string userInputID = Console.ReadLine();
                        userInputID = userInputID.ToUpper();
                        Console.WriteLine();
                        Console.WriteLine("Please enter the number of items you wish to purchase.");
                        int userInputAmount = Convert.ToInt32(Console.ReadLine());
                        fileAccess.Quantity_ID_NAME_PRODUCT_CODETracker(userInputAmount, CI.Name, userInputID); // reciept tracking method for items selected
                        ShoppingCartUI(userInputID, userInputAmount);
                        catering.RemoveFromItem(userInputID, userInputAmount);
                        PrintShoppingCartMenu();
                        ShoppingCartMenuSelection();
                        //fileAccess.Quantity_ID_NAME_PRODUCT_CODETracker(userInputAmount, CI.Name, userInputID); // reciept tracking method for items selected
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
                PrintShoppingCartMenu();
                ShoppingCartMenuSelection();
            }
            PrintOrderMenu();
            OrderSelection();
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
                AddMoneySelection();
            }
            PrintOrderMenu();
            OrderSelection();
        }

        private void PrintAddMoneyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Your account balance is: $" + catering.AccountBalance);
            Console.WriteLine("1 - Add more money");
            Console.WriteLine("2 - Return to Order Screen");
            return;
        }

        public void ShoppingCartUI(string userInputID, int userInputAmount)
        {
            while (!catering.ProductExists(userInputID, userInputAmount) || !catering.ProductAvailable(userInputID, userInputAmount) || !catering.SufficientStock(userInputID, userInputAmount))
            {
                if (!catering.ProductExists(userInputID, userInputAmount))
                {
                    Console.WriteLine();
                    Console.WriteLine("Product does not exist, please make another selection.");
                    userInputID = Console.ReadLine();
                    userInputID = userInputID.ToUpper();
                    Console.WriteLine();
                    Console.WriteLine("Please enter the number of items you wish to purchase.");
                    int intuserInputAmount = Convert.ToInt32(Console.ReadLine());
                  
                }
                else if (!catering.ProductAvailable(userInputID, userInputAmount))
                {
                    Console.WriteLine();
                    Console.WriteLine("Product is sold out, please make another selection.");
                    userInputID = Console.ReadLine();
                    userInputID = userInputID.ToUpper();
                    Console.WriteLine();
                    Console.WriteLine("Please enter the number of items you wish to purchase.");
                    userInputAmount = Convert.ToInt32(Console.ReadLine());
                }
                else if (!catering.SufficientStock(userInputID, userInputAmount))
                {
                    Console.WriteLine();
                    Console.WriteLine("Insufficient stock, enter a different amount.");
                    userInputAmount = Convert.ToInt32(Console.ReadLine());
                }
            }
            if (userInputAmount > 0)
            {
                catering.AddToShoppingCart(userInputID, userInputAmount);

            }
        }

        private void AddMoney(string userMoneyInput)
        {
            decimal incomingMoney = Convert.ToDecimal(userMoneyInput);

            while (!catering.IsPositive(incomingMoney) || !catering.LessThan5000(incomingMoney))
            {
                catering.IsPositive(incomingMoney);
                while (!catering.IsPositive(incomingMoney))
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a positive number:");
                    incomingMoney = Convert.ToDecimal(Console.ReadLine());
                }

                catering.LessThan5000(incomingMoney);
                while (!catering.LessThan5000(incomingMoney))
                {
                    Console.WriteLine();
                    Console.WriteLine("The maximum account balance allowed is $5000.");
                    Console.WriteLine("Your current balance is: $" + catering.AccountBalance + ".");
                    incomingMoney = Convert.ToDecimal(Console.ReadLine());
                }
            }
            catering.AccountBalance += incomingMoney;
        }
      private void CalculateChangeToReturn()
        {
            if (catering.AccountBalance - catering.ShoppingCartTotal >= 0)
            {
                catering.AmountDueBack = catering.AccountBalance - catering.ShoppingCartTotal;
                catering.ChangeToReturn();
                Console.WriteLine(catering.ChangeToReturnText());
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You do not have enough money in your account balance.");
                Console.WriteLine("Please add more money and try again.");
                PrintOrderMenu();
                OrderSelection();
            }

        }
    }
}
