using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one type of a catering item
        public string Name { get; set; } = "";
        public string IdentifierCode { get; set; } = "";
        public decimal Price { get; set; }
        public string Type { get; set; } = "";
        public int Quantity { get; set; } = 50;
       

       
        public CateringItem()
        {

        }
        public CateringItem(string indentifierCode, string name, decimal price, string type)
        {
            Name = name;
            IdentifierCode = indentifierCode;
            Price = price;
            Type = type;
        }

        public override string ToString()
      
        {
            //return IdentifierCode.PadRight(20) + Name.PadRight(15) + Price.ToString("F2").PadRight(20) + Type.PadRight(10) + startingQuantity;
            return String.Format("{0, -5} {1, -30} {2, -15} {3, -15} {4, -15}", IdentifierCode, Name, Price, Type, Quantity);

        }
    }
}
