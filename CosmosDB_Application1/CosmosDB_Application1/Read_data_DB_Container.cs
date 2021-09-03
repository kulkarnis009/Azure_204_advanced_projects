using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB_Application1
{
    class Read_data_DB_Container:Program
    {

        public void Read_data_DB_Container_method()
        {

            CosmosClient cosmosClient = new CosmosClient(_connection_string, new CosmosClientOptions() { AllowBulkExecution = true });

            Container container = cosmosClient.GetContainer(_database_name, _container_name);

            string inputQuery = "Select * from c order by c.id";

            QueryDefinition queryDefinition = new QueryDefinition(inputQuery);

            FeedIterator<Data> feedIterator = container.GetItemQueryIterator<Data>(queryDefinition);

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<Data> feedResponse = feedIterator.ReadNextAsync().GetAwaiter().GetResult();
                foreach (Data dataresult in feedResponse)
                { 
                    Console.WriteLine($"Id:{dataresult.id}");
                    Console.WriteLine($"CourseID:{dataresult.courseid}");
                    Console.WriteLine($"CourseName:{dataresult.coursename}");
                    Console.WriteLine($"CourseRating:{dataresult.courserating}");
                }
            }

        }
    }
}
