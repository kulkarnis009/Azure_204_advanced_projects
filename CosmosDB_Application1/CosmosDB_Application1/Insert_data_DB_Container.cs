using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Insert_data_DB_Container : Program
    {
        public void Insert_data_DB_Container_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string);

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            Data data = new Data()
            {
                id = "5",
                courseid = "AZ-305",
                coursename = "Random cert2",
                courserating = 5.2,
                order = new List<Order>
                {
                    new Order { orderid = "1", orderprice = 100.57 },
                    new Order { orderid = "2", orderprice = 2000 }
                }
        };

            container.CreateItemAsync<Data>(data, new PartitionKey(data.courseid)).GetAwaiter().GetResult();

            Console.WriteLine($"Item is created for {data.courseid}");
        }

    }
}
