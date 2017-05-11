using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public interface IDataContext
    {
        Task SaveAzureResources(IEnumerable<AzureResource> data);

        Task SaveWebSitePlans(IEnumerable<WebSitePlan> data);
    }
}
