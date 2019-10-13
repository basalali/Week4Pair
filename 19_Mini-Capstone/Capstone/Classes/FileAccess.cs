using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    class FileAccess
    {
        // This class should contain any and all details of access to files
        //Catering catering = new Catering();

        public List<CateringItem> ReadFromFile()
        {

            List<CateringItem> shoppingItems = new List<CateringItem>();
            string directory = @"C:\Catering";
            string fileName = "cateringsystem.csv";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] values = line.Split('|');

                        CateringItem items = new CateringItem();
                        items.IdentifierCode = values[0];
                        items.Name = values[1];
                        items.Price = decimal.Parse(values[2]);
                        items.Type = values[3];
                        items.Quantity = 50;

                        shoppingItems.Add(items);
                    }
            }

            catch(IOException e)
            {
                shoppingItems = new List<CateringItem>();
                Console.WriteLine(e.Message);
            }
            return shoppingItems;
        }
        /*
     All purchases must be audited to track orders and amounts in the catering system
    Each purchase should generate a line in a file called ​Log.txt
    The audit entry should include the date, time, action taken, and new customer balance
    Actions Taken may be:
    ADD MONEY
    GIVE CHANGE
    NUMBER_ORDERED PRODUCT_NAME PRODUCT_CODE
    The audit entries should be in the format:
        01/01/2019 12:00:00 PM ADD MONEY: $500.00 $500.00 (amount addded, current balance)
        01/01/2019 12:00:15 PM ADD MONEY: $250.00 $750.00 ''      ''
        01/01/2019 12:00:20 PM 15 Chicken E4 $112.50 $637.50  (number of items ordered, name of item, ID, total cost, current balance)
        01/01/2019 12:01:25 PM 9 Red Wine B2 $29.25 $608.25
        01/01/2019 12:01:35 PM GIVE CHANGE: $608.25 $0.00 (change given back current account balance)
    */


        public string AddMoneyTracker(string message)
        {
            string result = "";
            Catering catering = new Catering();
            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {

                     result = ($"{DateTime.UtcNow} Add Money: {message} {catering.AccountBalance}");
                     sw.WriteLine(result);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }



        public string Quantity_ID_NAME_PRODUCT_CODETracker(int quantity, string ID)
        {
            
            //(number of items ordered, name of item, ID, total cost, current balance)
            string result = "";
            Catering catering = new Catering();
            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    result = ($"{DateTime.UtcNow} {quantity} {ID} {catering.AccountBalance}");
                    sw.WriteLine(result);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public string GiveChangeTracker() // changetoreturn() where it deletes from account balance
        {
            // 01/01/2019 12:01:35 PM GIVE CHANGE: $608.25 $0.00 (change given back current account balance)
            string result = "";
            Catering catering = new Catering();
            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    result = ($"{DateTime.UtcNow} GIVE CHANGE: {catering.AmountDueBack} {catering.AccountBalance}");
                    sw.WriteLine(result);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }






}


