using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Execute_stored_procedure_Cosmos_DB : Program
    {
        public void Execute_stored_procedure_Cosmos_DB_method()
        {
            CosmosClient cosmosclient = new CosmosClient(_connection_string,new CosmosClientOptions() { AllowBulkExecution = true });

            Container container = cosmosclient.GetContainer(_database_name, _container_name);

            string output=container.Scripts.ExecuteStoredProcedureAsync<string>("demo", new PartitionKey(String.Empty),null).GetAwaiter().GetResult();

            Console.WriteLine(output);

        }
    }
}