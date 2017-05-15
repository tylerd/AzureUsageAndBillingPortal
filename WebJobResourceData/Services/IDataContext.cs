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
        Task SaveAzureResourcesAsync(IEnumerable<AzureResource> data);
    }
}
