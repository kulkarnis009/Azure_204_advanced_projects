using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Execute_stored_procedure_Additem_Cosmos_DB : Program
    {
        public void Execute_stored_procedure_Additem_Cosmos_DB_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string);

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            dynamic[] dynamics = new dynamic[]
            {
                new {id="7" ,courseid="AZ-555",coursename="Az all time great certification",courserating="10.99"}
            };
            
            string output = container.Scripts.ExecuteStoredProcedureAsync<string>("Additem", new PartitionKey("AZ-555"),new[] { dynamics}).GetAwaiter().GetResult();

            Console.WriteLine(output);
        }
    }
}