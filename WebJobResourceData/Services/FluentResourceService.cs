using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public class FluentResourceService : IResourceService
    {
        private AzureCredentials _cred;
        public FluentResourceService()
        {
            
        }

        public async Task<IEnumerable<AzureResource>> GetResourcesAsync(string subscriptionId)
        {
            var az = Initialize(subscriptionId);

            var arm = az.WebApps.Manager.ResourceManager.GenericResources;

            var res = await arm.ListAsync();

            var result = new List<AzureResource>();

            foreach (var r in res)
            {
                var newResource = new AzureResource { ResourceType = r.ResourceType, ResourceUri = r.Id, Tags = SerializeTags(r.Tags) };
                if (r.ResourceProviderNamespace == "Microsoft.Web" && r.ResourceType == "sites")
                {
                    var fullResource = arm.Get(r.ResourceGroupName, r.ResourceProviderNamespace, r.ParentResourceId, r.ResourceType, r.Name, "2016-03-01");
                    var serverFarmId = (string) (fullResource.Properties as JObject)["serverFarmId"];
                    newResource.ServerFarmId = serverFarmId;
                }
                

                result.Add(newResource);
            }

            return result;
        }

        private string SerializeTags(IReadOnlyDictionary<string, string> Tags)
        {
            if (Tags == null) return null;

            return JsonConvert.SerializeObject(Tags);
        }

        private IAzure Initialize(string subscriptionId)
        {
            if(_cred is null)
            {
                var clientId = ConfigurationManager.AppSettings["ida:ClientID"];
                var clientSecret = ConfigurationManager.AppSettings["ida:Password"];
                var tenantId = ConfigurationManager.AppSettings["ida:TenantId"];

                _cred = new AzureCredentials(new ServicePrincipalLoginInformation
                {
                    ClientId =  clientId,
                    ClientSecret = clientSecret,
                }, tenantId, AzureEnvironment.AzureGlobalCloud);
            }

            return Azure.Configure().Authenticate(_cred).WithSubscription(subscriptionId);
        }
    }
}
