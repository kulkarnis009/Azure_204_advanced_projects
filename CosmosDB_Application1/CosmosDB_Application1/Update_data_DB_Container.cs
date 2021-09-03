using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Update_data_DB_Container:Program
    {

        public void Update_data_DB_Container_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string);

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            string query = "update c set c.courserating=4.1 where c.course='AZ-900'";

            string _id = "1";

            string _partition_key = "AZ-900";

            ItemResponse<Data> response=container.ReadItemAsync<Data>(_id, new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            Data _data = response.Resource;

            _data.courserating = 4.1;

            container.ReplaceItemAsync(_data, _id, new PartitionKey(_partition_key)).GetAwaiter().GetResult();

            Console.WriteLine($"Rating has been update for {_partition_key}");

            

        }
    }
}
