using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlobStorageMetadataUpdate
{
    class Program
    {
        //This will update the value if key is already exist or add new
        //Enter connectionstring of your storage account, containername, blobname, metadata key and updated value
        private static string _connectionstring = "";
        private static string _containername = "data";
        private static string _blobname = "sample.txt";
        private static string _metadata_key_update = "Owner";
        private static string _metadata_updated_value = "Saurabh Kulkarni";
        private static IDictionary<string, string> metadataproperties;
        private static int _decision = 0;
        
        static async Task Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionstring);
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(_containername);
            BlobClient blobClient = blobContainerClient.GetBlobClient(_blobname);

            metadataproperties = new Dictionary<string, string>();
            metadataproperties.Add(_metadata_key_update, _metadata_updated_value);
            //Or
            //metadataproperties[_metadata_key_update] = _metadata_updated_value;

            Console.WriteLine("Decide whether to update via 1.setmetadata or 2.setmetadataasync");
            _decision = Convert.ToInt32(Console.ReadLine());
           
            //solution 1 
            if (_decision == 1)
            {
                blobClient.SetMetadata(metadataproperties);
                Console.WriteLine("Metadata updated using Setmetadata");
            }

            //Or Solution 2
            else if (_decision == 2)
                await AddBlobMetadataAsync(blobClient);

            else
                Console.WriteLine("Invalid choice");


            Console.ReadKey();
        }

        public static async Task AddBlobMetadataAsync(BlobClient blob)
        {
            await blob.SetMetadataAsync(metadataproperties);
            Console.WriteLine("Metadata updated using SetmetadataAsync");
        }
    }
}
