using Microsoft.Graph;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphApi
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                getUsersAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public async static Task getUsersAsync()
        {
            var clientId = "62e0e957-f85b-48fb-b47b-3610f4caea8e";
            var tenantId = "179f5470-7ce7-4833-a003-94075bd43eba";
            var clientSecret = "5s4~PCmIA8rw_4_kXe~JUk-GflkJHP8To~";
            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
            GraphServiceClient graphClient = new GraphServiceClient(authProvider);

            var groups = await graphClient.Groups.Request().Select(x => new { x.Id, x.DisplayName }).GetAsync();
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.DisplayName}, {group.Id}");
            }
        }
    }
}


