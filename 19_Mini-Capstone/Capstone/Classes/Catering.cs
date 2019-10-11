using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {

        public decimal accountBalance { get; set; }

        private List<CateringItem> items = new List<CateringItem>();
        private List<CateringItem> shoppingCart = new List<CateringItem>();
        private string filePath = @"C:\Catering";

        
        public Catering()
        {
            FileAccess fileaccess = new FileAccess();
            items = fileaccess.ReadFromFile();
        }

        public List<CateringItem> GetCateringItems()
        {
            return items;
        }

        public string DisplaySelectionMenu()
        {
            string display = "";
            if (items != null && items.Count > 0)
            {
                foreach (CateringItem item in items)
                {
                    display = display + item + Environment.NewLine;

                }
                return display;
            }
            else
            {
                return "Read from file failed";
            }
           // return "";
        }

        public bool ProductExists(string identifierCode)
        {
            bool result = false;
            foreach(CateringItem item in items)
            {
                if(item.IdentifierCode == identifierCode)
                {
                    result = true;
                }

            }
            return result;
        }

        public bool ProductSoldOut()
        {
            bool exists = true;
            CateringItem cateringItem = new CateringItem();
            if (cateringItem.Quantity == 0)
            {
                exists = false;
            }
            return exists;
        }

        private bool InsufficientStock(int desiredAmount)
        {
            bool exists = true;
            CateringItem cateringItem = new CateringItem();
            if (cateringItem.Quantity < desiredAmount)
            {
                exists = false;
            }
            return exists;
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

            while (incomingMoney + accountBalance > 5000)
            {
                Console.WriteLine();
                Console.WriteLine("The maximum account balance allowed is $5000. Your account is currently at $" + accountBalance + ".");
                Console.WriteLine("The most you are able to deposit at this time is $" + (5000 - accountBalance) + ". Please enter a valid deposit amount.");
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
            accountBalance += incomingMoney;
            return;
        }

        public string ChangeReturned()
        {
            int numberOfHundreds = 0;
            string hundreds = "";
            while (accountBalance >= 100M)
            {
                numberOfHundreds++;
                accountBalance -= 100M;
            }
            if (numberOfHundreds > 0)
            {
                hundreds = (numberOfHundreds + " $100 bill(s), ");
            }

            int numberOfFifties = 0;
            string fifties = "";
            while (accountBalance >= 50M)
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
            while (accountBalance >= 20M)
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
            while (accountBalance >= 10M)
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
            while (accountBalance >= 5M)
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
            while (accountBalance >= 1M)
            {
                numberOfOnes++;
                accountBalance -= 1M;
            }
            if (numberOfOnes > 0)
            {
                ones = (numberOfOnes + " $1 bill(s), ");
            }

            int numberOfQuarters = 0;
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

            int numberOfDimes = 0;
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
            string nickels = "";
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


        // need to set accountBalance to 0 at beginning, reset after customer orders

    }
}

