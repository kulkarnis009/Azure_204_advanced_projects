using Azure.Identity;
using Azure.Storage.Blobs;
using System;

namespace BlobDownloadConsoleApp1
{
    class Program
    {
        //private static string blob_connectin_string = "DefaultEndpointsProtocol=https;AccountName=az204storageaccount10;AccountKey=2yXHDDFJA7PJERDQkc1YIqawKfrHk+V/dQ2eESBNKhYlQLfDORBrWcyloWwDZQEbq7+Da1CKlpwT5gGfAIr6zQ==;EndpointSuffix=core.windows.net";
        //private static string container_name = "data";
        private static string blobUrl = "https://az204storageaccount10.blob.core.windows.net/data/sample.txt";
        private static string local_blob = "C:\\Users\\saurabh.d.kulkarni\\Desktop\\fromBlob\\sample.txt";
        private static string blob_name = "sample.txt";

        private static string tenantid = "0903ea1c-f001-47e9-bbc6-a16a789f9d2f";
        private static string clientid = "1ab34ca1-0bd1-48f2-86c3-ce97838c5982";
        private static string clientsecretid = "TfWRX94f~i.3q-L6dFkZxf2iEUHhy1.9Rj";
        
        static void Main(string[] args)
        {

            //BlobServiceClient blobServiceClient = new BlobServiceClient(blob_connectin_string);

            //BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(container_name);

            //BlobClient blobClient = blobContainerClient.GetBlobClient(blob_name);

            ClientSecretCredential clientsecretcredential = new ClientSecretCredential(tenantid,clientid,clientsecretid);

            Uri blobUri = new Uri(blobUrl);
            BlobClient blobClient = new BlobClient(blobUri,clientsecretcredential);

            blobClient.DownloadTo(local_blob);

            Console.WriteLine($"Blob has been downloaded at {local_blob}");
            Console.ReadKey();
        }
    }
}
