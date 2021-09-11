using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace KeyVaultAppConsole2
{
    class Program
    {
        private static string keyvalut_url = "https://az204keyvault3.vault.azure.net/";
        private static string secret_name = "password2";

        static void Main(string[] args)
        {

            TokenCredential credential = new DefaultAzureCredential();

            SecretClient secretClient = new SecretClient(new Uri(keyvalut_url), credential);

            var secret=secretClient.GetSecret(secret_name);

            Console.WriteLine($"The secret is {secret.Value.Value}");
        }
    }
}
