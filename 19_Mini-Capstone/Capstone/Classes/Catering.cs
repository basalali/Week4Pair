using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {

        public decimal AccountBalance { get; set; }
        public decimal AmountDueBack { get; set; }
        public decimal ShoppingCartTotal { get; set; }

        private List<CateringItem> items = new List<CateringItem>();
        private List<CateringItem> shoppingCart = new List<CateringItem>();
        private Dictionary<decimal, int> changeToReturn = new Dictionary<decimal, int>();
      
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

                    ShoppingCartTotal += (product.Quantity * product.Price);                   
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

        public bool IsPositive(decimal incomingMoney)
        {
            bool isPositive = true;
            if (incomingMoney < 0)
            {
                isPositive = false;
            }
            return isPositive;
        }

        public bool LessThan5000(decimal incomingMoney)
        {
            bool lessThan5000 = true;
            if (incomingMoney + AccountBalance > 5000)
            {
                lessThan5000 = false;
            }
            return lessThan5000;
        }

        public void ChangeToReturn()
        {
            List<decimal> currency = new List<decimal> { 100, 50, 20, 10, 5, 1, .25M, .1M, .05M, .01M };

            foreach(decimal billOrCoin in currency)
            {
                int numberOfBillOrCoin = 0;
                while (AmountDueBack > billOrCoin)
                {
                    numberOfBillOrCoin++;
                    AmountDueBack -= billOrCoin;
                }
                if (numberOfBillOrCoin > 0)
                {
                    changeToReturn.Add(billOrCoin, numberOfBillOrCoin);
                }
            }
        }

        public string ChangeToReturnText()
        {
            string result = "";
            foreach (KeyValuePair<decimal, int> entry in changeToReturn)
            {
                result = result + entry.Value + " x $" + entry.Key + Environment.NewLine;
            }
            if (result == "")
            {
                return "Your account balance was equal to the amount of your purchase. You are due no change.";
            }
            else
            {
                return "Your change is: " + Environment.NewLine + result;
            }
        }
    }
}

