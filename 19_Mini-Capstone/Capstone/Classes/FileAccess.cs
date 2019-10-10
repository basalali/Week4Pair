using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    class FileAccess
    {
        // This class should contain any and all details of access to files

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
                        items.Type = values[2];
                        items.Price = decimal.Parse(values[3]);
                        items.startingQuantity = 50;

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

    }

}
