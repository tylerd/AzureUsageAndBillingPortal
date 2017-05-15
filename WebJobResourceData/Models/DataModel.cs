using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobResourceData.Models
{
    public class DataModel : DbContext
    {
        public DataModel(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<AzureResource> AzureResource { get; set; }
    }

}
