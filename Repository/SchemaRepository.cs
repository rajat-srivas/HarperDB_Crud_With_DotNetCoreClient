using System;
using harperdb_crud.Utility;
using Newtonsoft.Json;

namespace harperdb_crud.Repository
{
    public class SchemaRepository : ISchemaRepository
    {
        private HarperNetClient.IHarperClient _harperClient;
        private ConfigurationHandler configHandler;
        private HarperNetClient.models.HarperDbConfiguration _harperDbConfig;
        public SchemaRepository(IConfigurationHandler config)
        {
            configHandler = (ConfigurationHandler)config;
            _harperDbConfig = configHandler.GetHarperDbConfiguration();
            _harperClient = new HarperNetClient.HarperClient(_harperDbConfig);
        }

        public string CreateTable(string table, string schema)
        {
            var response = _harperClient.CreateTable(table, _harperDbConfig.Schema);
                return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Message;
        }
    }
}
