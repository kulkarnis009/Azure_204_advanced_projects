using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AZ_204_Cosmos_DB_FunctionApp1
{
    public static class DetectChanges
    {
        [FunctionName("ReadChange")]
        public static void Run([CosmosDBTrigger(
            databaseName: "az-204_cosmos_DB_1",
            collectionName: "course",
            ConnectionStringSetting = "az_204_cosmos_DB_1_conn",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                foreach(var _course in input)
                {
                    log.LogInformation($"Id {_course.Id}");
                    log.LogInformation($"Course Id {_course.GetPropertyValue<string>("courseid")}");
                    log.LogInformation($"Course Name {_course.GetPropertyValue<string>("coursename")}");

                }
            }
        }
    }
}
