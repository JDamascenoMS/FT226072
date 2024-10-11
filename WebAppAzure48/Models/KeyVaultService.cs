using Microsoft.Azure.KeyVault;
using Azure.Identity;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Diagnostics;

namespace WebAppAzure48.Models
{


    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService()
        {
            try
            {
                var clientSecretCredential = new ClientSecretCredential(
                tenantId: "",
                clientId: "",
                clientSecret: "");

                string keyVaultUrl = "https://webappazure48vaultjulio2.vault.azure.net/";

                _secretClient = new SecretClient(new Uri(keyVaultUrl), clientSecretCredential);
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
            return secret.Value;
        }
        public async Task<string> CreateSecretAsync(string secretName, string secretValue)
        {
            try
            {
                KeyVaultSecret secret = _secretClient.SetSecret(new KeyVaultSecret(secretName, secretValue));
                return secret.Value;
            }
            catch(Exception ex) 
            { 
                Debug.WriteLine(ex);
                return string.Empty;
            }
            
        }
    }
}