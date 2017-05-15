using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobResourceData.Models
{
    public class AzureResource
    {
        [Key,MaxLength(250)]
        public string ResourceUri { get; set; }
        [MaxLength(50)]
        public string ResourceType { get; set; }
        [MaxLength(1000)]
        public string Tags { get; set; }
        [MaxLength(250)]
        public string ServerFarmId { get; set; }
    }
}
