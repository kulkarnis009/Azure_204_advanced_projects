using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace KeyVaultAppConsoleApp1
{
    class Program
    {
        private static string tenantid = "0903ea1c-f001-47e9-bbc6-a16a789f9d2f";
        private static string clientid = "1ab34ca1-0bd1-48f2-86c3-ce97838c5982";
        private static string clintsecret = "~r6yU8nJJHxk1Wyb~-9eIasm1~N285r3.Q";

        private static string keyvaultUrl = "https://az204keyvault1.vault.azure.net/";
        private static string secret_name = "dbpassword";
        static void Main(string[] args)
        {

            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantid,clientid,clintsecret);

            SecretClient secretClient = new SecretClient(new Uri(keyvaultUrl),clientSecretCredential);

            var secretvar = secretClient.GetSecret(secret_name);
            
            Console.WriteLine($"Db password is : {secretvar.Value.Value}");

            Console.ReadKey();
        }
    }
}
