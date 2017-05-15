using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WebJobResourceData.Models;

namespace WebJobResourceData
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessResourceRequest([QueueTrigger("resourcedatarequests")] ResourceRequest message, TextWriter log)
        {
            log.WriteLine("Processing Resource Data Request for Subscription Id: " + message.SubscriptionId);

            var resourceService = Program.ResourceService;
            var dataContext = Program.DataContext;

            log.WriteLine("Initialized context");

            var data = resourceService.GetResourcesAsync(message.SubscriptionId).Result;

            log.WriteLine("Retrieved Resources - Count: " + data.Count());

            dataContext.SaveAzureResourcesAsync(data).Wait();

            log.WriteLine("Completed Save to DB");
        }
    }
}
