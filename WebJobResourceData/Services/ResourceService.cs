using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public class ResourceService : IResourceService
    {
        public async Task<IEnumerable<AzureResource>> GetResources(string subscriptionId)
        {
            
            var result = await Task.Run<IEnumerable<AzureResource>>(() =>
            {
                return new List<AzureResource>();
            });

            return result;
        }
    }
}
