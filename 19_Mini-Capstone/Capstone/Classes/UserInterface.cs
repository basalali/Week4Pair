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

        public decimal accountBalance { get; set; } 

        private Catering catering = new Catering();

        


        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.WriteLine("Press any enter to continue.");
                Console.ReadLine();
                accountBalance = 0;
                done = true;
            }
            // StockInventory(); Within this method, read inventory txt and add to data (all items should be at 50)

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



        //private void DisplayCateringItems()
        //{
        //    while()
        //    {


        //    }
        //}

        private void PrintOrderMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a choice:");
            Console.WriteLine("1 - Add money");
            Console.WriteLine("2 - Select products");
            Console.WriteLine("3 - Complete Transaction");
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
                        //SelectProducts();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
                PrintOrderMenu();
                orderSelection = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("Your change is $" + accountBalance + ". This will be ejected in the form of:");
            Console.WriteLine(ChangeReturned() + "momentarily.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
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
                }
            }
            accountBalance += incomingMoney;
            return;
        }

        private void PrintAddMoneyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Your account balance is: $" + accountBalance);
            Console.WriteLine("1 - Add more money");
            Console.WriteLine("2 - Return to Order Screen");
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

        private string ChangeReturned()
        {
            int numberOfHundreds = 0;
            string hundreds = "";
            while (accountBalance >= 100)
            {
                numberOfHundreds ++;
                accountBalance -= 100M;
            }
            if (numberOfHundreds > 0)
            {
                hundreds = (numberOfHundreds + " $100 bill(s), ");
            }

            int numberOfFifties = 0;
            string fifties = "";
            while (accountBalance >= 50)
            {
                numberOfFifties++;
                accountBalance -= 50M;
            }
            if (numberOfFifties > 0)
            {
                fifties = (numberOfFifties + " $50 bill, ");
            }

            int numberOfTwenties = 0;
            string twenties = "";
            while (accountBalance >= 20)
            {
                numberOfTwenties++;
                accountBalance -= 20M;
            }
            if (numberOfTwenties > 0)
            {
                twenties = (numberOfTwenties + " $20 bill(s), ");
            }

            int numberOfTens = 0;
            string tens = "";
            while (accountBalance >= 10)
            {
                numberOfTens++;
                accountBalance -= 10M;
            }
            if (numberOfTens > 0)
            {
                tens = (numberOfTens + " $10 bill, ");
            }

            int numberOfFives = 0;
            string fives = "";
            while (accountBalance >= 5)
            {
                numberOfFives++;
                accountBalance -= 5M;
            }
            if (numberOfFives > 0)
            {
                fives = (numberOfFives + " $5 bill, ");
            }

            int numberOfOnes = 0;
            string ones = "";
            while (accountBalance >= 1)
            {
                numberOfOnes++;
                accountBalance -= 1M;
            }
            if (numberOfOnes > 0)
            {
                ones = (numberOfOnes + " $1 bill(s), ");
            }

            double numberOfQuarters = 0;
            string quarters = "";
            while (accountBalance >= .25M)
            {
                numberOfQuarters++;
                accountBalance -= .25M;
            }
            if (numberOfQuarters > 0)
            {
                quarters = (numberOfQuarters + " quarter(s), ");
            }

            double numberOfDimes = 0;
            string dimes = "";
            while (accountBalance >= .1M)
            {
                numberOfDimes++;
                accountBalance -= .1M;
            }
            if (numberOfDimes > 0)
            {
                dimes = (numberOfDimes + " dime(s), ");
            }

            int numberOfNickels = 0;
            string nickels= "";
            while (accountBalance >= .05M)
            {
                numberOfNickels++;
                accountBalance -= .05M;
            }
            if (numberOfNickels > 0)
            {
                nickels = (numberOfNickels + " nickel, ");
            }

            int numberOfPennies = 0;
            string pennies = "";
            while (accountBalance >= .01M)
            {
                numberOfPennies++;
                accountBalance -= .01M;
            }
            if (numberOfPennies > 0)
            {
                pennies = (numberOfPennies + " penny(s) ");
            }

            return (hundreds + fifties + twenties + tens + fives + ones + quarters + dimes + nickels + pennies);
        }

        private void DisplaySelectionMenu()
        {
            List<CateringItem> result = catering.GetCateringItems();
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


    }
}
