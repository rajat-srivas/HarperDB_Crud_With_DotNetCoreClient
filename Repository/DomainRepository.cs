using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using harperdb_crud.models;
using harperdb_crud.Utility;
using Newtonsoft.Json;
using RestSharp;

namespace harperdb_crud.Repository
{
    public class DomainRepository : IDomainRepository
    {
        private HarperNetClient.IHarperClient _harperClient;
        private ConfigurationHandler configHandler;
        private HarperNetClient.models.HarperDbConfiguration _harperDbConfig;
        private string Schema_Table = "domain";

        public DomainRepository(IConfigurationHandler config)
        {
            configHandler = (ConfigurationHandler)config;
            _harperDbConfig = configHandler.GetHarperDbConfiguration();
            _harperClient = new HarperNetClient.HarperClient(_harperDbConfig, Schema_Table);
        }


        public string DeleteDomainById(string id)
        {
            string query = $"DELETE FROM {_harperDbConfig.Schema}.{Schema_Table} WHERE id = \"{id}\"";
            var response = _harperClient.ExecuteQuery(query);
            return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Message;
        }

        public string UpdateDomain(DomainTracking domain)
        {
            var response = _harperClient.UpdateRecord<DomainTracking>(domain);
            return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Message;

        }

        public List<string> CreateDomainTrackingFromCSV(string filePath)
        {
            filePath = "Users/rajatsrivastava/Projects/harperdb-crud/harperdb-crud/BulkImport.csv";

            var response = _harperClient.CreateBulkRecord<List<DomainTracking>>(filePath);
            return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Inserted_Hashes;
        }

        public string CreateDomain(DomainTracking domainToCreate)
        {
            var response = _harperClient.CreateRecord<DomainTracking>(domainToCreate);
            return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Inserted_Hashes[0];
        }
    }
}
