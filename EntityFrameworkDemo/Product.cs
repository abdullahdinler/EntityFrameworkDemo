using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal UnitePrice { get; set; }
        public int StockAmount { get; set; }
    }
}
