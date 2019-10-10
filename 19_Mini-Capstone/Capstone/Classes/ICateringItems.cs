using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public interface ICateringItems
    {
        string Name { get; }
        string IdentifierCode { get; }
        decimal Price { get; }

    }

}
