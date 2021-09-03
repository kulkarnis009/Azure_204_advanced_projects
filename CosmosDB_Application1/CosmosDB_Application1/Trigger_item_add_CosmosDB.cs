using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Trigger_item_add_CosmosDB : Program
    {
        public void Trigger_item_add_CosmosDB_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string, new CosmosClientOptions());

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            Data data = new Data()
            { id = "10", courseid = "SC-900", coursename = "Azure security fundamentals", courserating = 4.2 };

            container.CreateItemAsync<Data>(data, null, new ItemRequestOptions() { PreTriggers = new List<string> { "Addtimestamp" } }).GetAwaiter().GetResult();
            Console.WriteLine("New item is added with timestamp");

        }
    }
}