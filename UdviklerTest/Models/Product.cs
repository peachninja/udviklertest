using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UdviklerTest.Models
{
    public class Product
    {
        public string ProductGuid { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
    }
    public class ProductQuantity
    {
        public string ProductId { get; set; } //Insert product guid
        public int Quantity { get; set; } //Insert quantity
    }

    public class Order
    {
        public List<OrderLine> OrderLines { get; set; }
        public string HeaderGuid { get; set; }
    }
    public class OrderLine
    {
        public string LineGuid { get; set; }
        public double Quantity { get; set; }
    }


}