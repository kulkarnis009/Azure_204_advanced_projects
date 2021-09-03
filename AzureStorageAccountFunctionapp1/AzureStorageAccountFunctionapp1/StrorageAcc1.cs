using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureStorageAccountFunctionapp1
{
    public static class StrorageAcc1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("data/{name}", Connection = "_storage_connection_string")] Stream myBlob,
            [CosmosDB(
            databaseName:"Az-204_database-2",
            collectionName:"Az-204_container-2",
            ConnectionStringSetting ="CosmosDBConnectionString")] out dynamic document,
            string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            Blob _blob = new Blob()
            {
                blobid = Guid.NewGuid().ToString(),
                blobname = name,
                blobsize = myBlob.Length
            };

            document = _blob;
        }
    }
}
