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
            catch (IOException e)
            {
                shoppingItems = new List<CateringItem>();
                Console.WriteLine(e.Message);
            }
            return shoppingItems;
        }

        public string AddMoneyTracker(string message, decimal accountB)
        {
            string result = "";

            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {

                    result = ($"{DateTime.UtcNow} Add Money: {message} {accountB}");
                    sw.WriteLine(result);

                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        public string Quantity_ID_NAME_PRODUCT_CODETracker(int quantity, string name, string ID, decimal accountB, decimal shoppingCartTotal)
        {

            //(number of items ordered, name of item, ID, total cost, current balance)
            string result = "";

            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    result = ($"{DateTime.UtcNow} {quantity} {ID} {name} {accountB} {shoppingCartTotal}");
                    sw.WriteLine(result);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public string GiveChangeTracker(decimal accountB) // changetoreturn() where it deletes from account balance
            { 
            string result = "";
           
            string s = "";
            string directory = @"C:\Catering";
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {                    
                    result = ($"{DateTime.UtcNow} GIVEN CHANGE: {accountB} {0.00}");     
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
    

 