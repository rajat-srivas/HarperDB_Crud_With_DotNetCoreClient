using System;
using System.Collections.Generic;
using harperdb_crud.models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace harperdb_crud.Utility
{
    public class ConfigurationHandler : IConfigurationHandler
    {
        private IConfiguration config;
        public ConfigurationHandler(IConfiguration configuration)
        {
            config = configuration;
        }

        public HarperNetClient.models.HarperDbConfiguration GetHarperDbConfiguration()
        {
            var dbConfig = config.GetSection("HarperDbConfiguration").Get<HarperNetClient.models.HarperDbConfiguration>();
            return dbConfig;
        }

    }
}

