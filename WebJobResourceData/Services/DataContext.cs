using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebJobResourceData.Models;

namespace WebJobResourceData.Services
{
    public class DataContext : IDataContext
    {
        private DataModel _db;
        public DataContext()
        {
            _db = new DataModel("ASQLConn");
        }
        public async Task SaveAzureResourcesAsync(IEnumerable<AzureResource> data)
        {
            var table = _db.AzureResource;

            table.AddRange(data);

            await _db.SaveChangesAsync();
        }
    }
}
