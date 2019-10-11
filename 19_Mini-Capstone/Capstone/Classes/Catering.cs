using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {

        public decimal accountBalance { get; set; }
        public decimal amountDueBack { get; set; }
        public decimal shoppingCartTotal { get; set; }

        private List<CateringItem> items = new List<CateringItem>();
        private List<CateringItem> shoppingCart = new List<CateringItem>();
        //private string filePath = @"C:\Catering";

        
        public Catering()
        {
            FileAccess fileaccess = new FileAccess();
            items = fileaccess.ReadFromFile();
        }

        public List<CateringItem> GetCateringItems()
        {
            return items;
        }

        public void RemoveFromItem(string identifierCode, int quantity)
        {
            foreach (CateringItem item in items)
            {
                if (item.IdentifierCode == identifierCode)
                {
                    CateringItem temp = new CateringItem();
                    item.Quantity -= quantity;
                }
            }
        }

        public void AddToShoppingCart(string identifierCode, int quantity)
        {
            foreach(CateringItem item in items)
            {

                if (item.IdentifierCode == identifierCode)
                {
                    CateringItem product = new CateringItem();
                    product.IdentifierCode = identifierCode;
                    product.Name = item.Name;
                    product.Quantity = quantity;
                    product.Type = item.Type;
                    product.Price = item.Price;
                    shoppingCart.Add(product);

                    shoppingCartTotal += (product.Quantity * product.Price);
                    amountDueBack = accountBalance - shoppingCartTotal;
                }
            }
        }

        public string DisplayShoppingCart()
        {
            string display = "";
            if (shoppingCart != null && shoppingCart.Count > 0)
            {
                foreach (CateringItem item in shoppingCart)
                {
                    display = display + item + Environment.NewLine;

                }
                return display;
            }
            else
            {
                return "Read from file failed";
            }       
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
        }

        public bool ProductExists(string identifierCode, int desiredAmount)
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

        public bool ProductAvailable(string identifierCode, int desiredAmount)
        {
            bool exists = false;
            foreach (CateringItem item in items)
            {
                if (item.IdentifierCode == identifierCode && item.Quantity > 0)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public bool SufficientStock(string identifierCode, int desiredAmount)
        {
            bool exists = false;
       
            foreach (CateringItem item in items)
            {
               
                if (item.IdentifierCode == identifierCode && item.Quantity >= desiredAmount)
                {
                    exists = true;
                }
            }
            return exists;
        }

        //public bool ConvertMoneyToDecimal(string incomingMoney)
        //{
        //    bool converted = false;
        //    try
        //    {
        //        decimal convertedIncomingMoney = Convert.ToDecimal(incomingMoney);
        //        converted = true;
        //    }
        //    catch (FormatException)
        //    {                
        //    }                       
        //    return converted;
        //}

        //public bool IsPositive(decimal incomingMoney)
        //{
        //    bool isPositive = true;
        //    if (incomingMoney < 0)
        //    {
        //        isPositive = false;
        //    }
        //    return isPositive;
        //}

        public bool LessThan5000(decimal incomingMoney)
        {
            bool lessThan5000 = true;
            if (incomingMoney + accountBalance > 5000)
            {
                lessThan5000 = false;
            }
            return lessThan5000;
        }

        public string ChangeReturned()
        {
            int numberOfHundreds = 0;
            string hundreds = "";
            while (amountDueBack >= 100M)
            {
                numberOfHundreds++;
                amountDueBack -= 100M;
            }
            if (numberOfHundreds > 0)
            {
                hundreds = (numberOfHundreds + " $100 bill(s), ");
            }

            int numberOfFifties = 0;
            string fifties = "";
            while (amountDueBack >= 50M)
            {
                numberOfFifties++;
                amountDueBack -= 50M;
            }
            if (numberOfFifties > 0)
            {
                fifties = (numberOfFifties + " $50 bill, ");
            }

            int numberOfTwenties = 0;
            string twenties = "";
            while (amountDueBack >= 20M)
            {
                numberOfTwenties++;
                amountDueBack -= 20M;
            }
            if (numberOfTwenties > 0)
            {
                twenties = (numberOfTwenties + " $20 bill(s), ");
            }

            int numberOfTens = 0;
            string tens = "";
            while (amountDueBack >= 10M)
            {
                numberOfTens++;
                amountDueBack -= 10M;
            }
            if (numberOfTens > 0)
            {
                tens = (numberOfTens + " $10 bill, ");
            }

            int numberOfFives = 0;
            string fives = "";
            while (amountDueBack >= 5M)
            {
                numberOfFives++;
                amountDueBack -= 5M;
            }
            if (numberOfFives > 0)
            {
                fives = (numberOfFives + " $5 bill, ");
            }

            int numberOfOnes = 0;
            string ones = "";
            while (amountDueBack >= 1M)
            {
                numberOfOnes++;
                amountDueBack -= 1M;
            }
            if (numberOfOnes > 0)
            {
                ones = (numberOfOnes + " $1 bill(s), ");
            }

            int numberOfQuarters = 0;
            string quarters = "";
            while (amountDueBack >= .25M)
            {
                numberOfQuarters++;
                amountDueBack -= .25M;
            }
            if (numberOfQuarters > 0)
            {
                quarters = (numberOfQuarters + " quarter(s), ");
            }

            int numberOfDimes = 0;
            string dimes = "";
            while (amountDueBack >= .1M)
            {
                numberOfDimes++;
                amountDueBack -= .1M;
            }
            if (numberOfDimes > 0)
            {
                dimes = (numberOfDimes + " dime(s), ");
            }

            int numberOfNickels = 0;
            string nickels = "";
            while (amountDueBack >= .05M)
            {
                numberOfNickels++;
                amountDueBack -= .05M;
            }
            if (numberOfNickels > 0)
            {
                nickels = (numberOfNickels + " nickel, ");
            }

            int numberOfPennies = 0;
            string pennies = "";
            while (amountDueBack >= .01M)
            {
                numberOfPennies++;
                amountDueBack -= .01M;
            }
            if (numberOfPennies > 0)
            {
                pennies = (numberOfPennies + " penny(s) ");
            }

            accountBalance = amountDueBack;
            return (hundreds + fifties + twenties + tens + fives + ones + quarters + dimes + nickels + pennies);
        }


        // need to set accountBalance to 0 at beginning, reset after customer orders

    }
}

