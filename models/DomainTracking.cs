using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace harperdb_crud.models
{
    public class DomainTracking
    {
        public DomainTracking()
        {
        }

        [Key]
        [JsonIgnore]
        public string id { get; set; }

        public string DomainName { get; set; }

        public bool isAvailable { get; set; }

        public bool isTracking { get; set; }

        public string LinkedUser { get; set; }
    }
}

