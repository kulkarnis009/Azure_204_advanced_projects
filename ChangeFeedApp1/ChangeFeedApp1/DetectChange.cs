using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ChangeFeedApp1
{
    public static class DetectChange
    {
        [FunctionName("ReadChange")]
        public static void Run([CosmosDBTrigger(
            databaseName: "Az-204_database-2",
            collectionName: "Az-204_container-2",
            ConnectionStringSetting = "cosmosdbconnectionstring",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
               foreach(var data in input)
                {
                    log.LogInformation($"Id:{data.Id}");
                    log.LogInformation($"Course Id:{data.GetPropertyValue<string>("courseid")}");
                    log.LogInformation($"Course Name:{data.GetPropertyValue<string>("coursename")}");
                }
            }
        }
    }
}
