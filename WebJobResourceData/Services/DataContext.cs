using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public class DataContext : IDataContext
    {
        public Task SaveAzureResources(IEnumerable<AzureResource> data)
        {
            throw new NotImplementedException();
        }

        public Task SaveWebSitePlans(IEnumerable<WebSitePlan> data)
        {
            throw new NotImplementedException();
        }
    }
}
