using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDB_Application1
{
    class Insert_bulk_data_DB_Container:Program
    {

        public void Insert_bulk_data_DB_Container_method()
        {
            CosmosClient cosmosClient = new CosmosClient(_connection_string, new CosmosClientOptions() {AllowBulkExecution=true });

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            List<Data> datalist = new List<Data>
            {

                new Data() { id="1",courseid="AZ-900",coursename="Azure Fundamentals",courserating=4 },
                new Data() { id="2",courseid="AZ-204",coursename="Azure developer",courserating=4.5 },
                new Data() { id="3",courseid="AZ-303",coursename="Azure random cert",courserating=4.7 },
                new Data() { id="4",courseid="AZ-304",coursename="Azure Architecture",courserating=5 }
            };

            List<Task> tasks = new List<Task>();


            foreach (Data dataitem in datalist)
                tasks.Add(container.CreateItemAsync<Data>(dataitem, new PartitionKey(dataitem.courseid)));

            Task.WhenAll(tasks).GetAwaiter().GetResult();

            Console.WriteLine("All items are inserted successfully");
        }
    }
}
