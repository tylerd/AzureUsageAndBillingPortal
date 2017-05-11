using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WebJobResourceData.Services;

namespace WebJobResourceData
{
    // To learn more about Microsoft Azure WebJobs SDK, please see https://go.microsoft.com/fwlink/?LinkID=320976
    public class Program
    {
        private static IResourceService _resourceService;
        public static IResourceService ResourceService
        {
            get { return _resourceService; }
        }

        private static IDataContext _dataContext;
        public static IDataContext DataContext
        {
            get { return _dataContext; }
        }

        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        public static void Main()
        {
            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            _resourceService = new ResourceService();
            _dataContext = new DataContext();

            var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
