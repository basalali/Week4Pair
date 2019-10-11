using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering
      
        private List<CateringItem> items = new List<CateringItem>();
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

        private List<CateringItem> shoppingCart = new List<CateringItem>();

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



        // need to set accountBalance to 0 at beginning, reset after customer orders

    }
}

