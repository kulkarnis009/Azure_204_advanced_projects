using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Text;

namespace KeyVaultAppConsoleApp1
{
    class Program
    {
        private static string tenantid = "0903ea1c-f001-47e9-bbc6-a16a789f9d2f";
        private static string clientid = "1ab34ca1-0bd1-48f2-86c3-ce97838c5982";
        private static string clintsecret = "~r6yU8nJJHxk1Wyb~-9eIasm1~N285r3.Q";

        private static string keyvaultUrl = "https://az204keyvault1.vault.azure.net/";
        //private static string secret_name = "dbpassword";
        private static string key_name = "dbpassword2";
        private static string key_to_encrypt = "This text need to encrypted";

        static void Main(string[] args)
        {

            ClientSecretCredential clientSecretCredential = new ClientSecretCredential(tenantid,clientid,clintsecret);

            //SecretClient secretClient = new SecretClient(new Uri(keyvaultUrl),clientSecretCredential);

            KeyClient keyClient = new KeyClient(new Uri(keyvaultUrl), clientSecretCredential);

            //var secretvar = secretClient.GetSecret(secret_name);

            var _key = keyClient.GetKey(key_name);

            var crypto_client = new CryptographyClient(_key.Value.Id, clientSecretCredential);

            byte[] text_to_bytes = Encoding.UTF8.GetBytes(key_to_encrypt);

            //Encryption
            EncryptResult result = crypto_client.Encrypt(EncryptionAlgorithm.RsaOaep, text_to_bytes);

            Console.WriteLine($"Encrypted text is {Convert.ToBase64String(result.Ciphertext)}");
            //Console.WriteLine($"Db password is : {secretvar.Value.Value}");


            //Decryption
            byte[] byte_to_text = result.Ciphertext;

            DecryptResult decryptResult = crypto_client.Decrypt(EncryptionAlgorithm.RsaOaep, byte_to_text);

            Console.WriteLine($"Decrypted text is: {Encoding.UTF8.GetString(decryptResult.Plaintext)}");

            Console.ReadKey();
        }
    }
}
