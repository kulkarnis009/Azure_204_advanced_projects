using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Create_DB_Container : Program
    {
        public void Create_DB_Container_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string);

            cosmosClient.CreateDatabaseAsync(_database_name).GetAwaiter().GetResult();

            Database database = cosmosClient.GetDatabase(_database_name);

            database.CreateContainerAsync(_container_name, _partition_key).GetAwaiter().GetResult();

            Console.WriteLine("Database and Container are created successfully.");

            Console.ReadLine();
        }
    }

}