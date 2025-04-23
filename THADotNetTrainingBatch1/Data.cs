using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1
{
    internal class Data
    {
        public static int ProductId = 2;
        public static List<Product> Products = new List<Product>()
        {
            new Product(1, "P001" , "Apple" , 3000 , 100 , "Fruit"),
            new Product(2, "P002" , "Banana" , 1000 , 150 , "Fruit"),
        };
    }
}
