using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Delete_data_DB_Container:Program
    {

        public void Delete_data_DB_Container_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string);

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            string _id = "3";

            string _partition_key = "AZ-303";

            container.DeleteItemAsync<Data>(_id, new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            Console.WriteLine($"Item deleted for {_partition_key}");
        
        }
    }
}
