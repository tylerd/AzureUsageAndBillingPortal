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
        public static async void ProcessResourceRequest([QueueTrigger("resourcedatarequests")] ResourceRequest message, TextWriter log)
        {
            log.WriteLine("Processing Resource Data Request for Subscription Id: " + message.SubscriptionId);

            var resourceService = Program.ResourceService;
            var dataContext = Program.DataContext;

            var data = await resourceService.GetResources(message.SubscriptionId);

            await dataContext.SaveAzureResources(data);
        }
    }
}
