using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UdviklerTest.Models
{
    public class PostData
    {
        public string ApiKey { get; set; } //Always empty
        public string UserName { get; set; } //Always use “Smart”
        public string Password { get; set; } //Always use “udviklertest”
        public string ClientCustomerNo { get; set; } //Always empty
        public string customerGuid { get; set; } //Always empty
        public string[] LineIds { get; set; } //Only needed for some services
        public List<ProductQuantity> ProductQuantities { get; set; } //Only needed for some services
        public Order Order { get; set; } //Only needed for some services

    }
}