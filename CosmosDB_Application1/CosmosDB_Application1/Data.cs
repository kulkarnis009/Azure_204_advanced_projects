using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Data
    {

        public string id { get; set; }
        public string courseid { get; set; }
        public string coursename { get; set; }
        public double courserating { get; set; }

        public List<Order> order { get; set; }

    }

    class Order
    {
        public string orderid { get; set; }

        public double orderprice { get; set; }
    }
}
