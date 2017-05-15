using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public interface IResourceService
    {
        Task<IEnumerable<AzureResource>> GetResourcesAsync(string subscriptionId);
    }
}
