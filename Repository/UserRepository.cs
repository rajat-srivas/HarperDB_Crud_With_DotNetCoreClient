using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using harperdb_crud.models;
using harperdb_crud.Utility;
using Newtonsoft.Json;
using RestSharp;

namespace harperdb_crud.Repository
{
    public class UserRepository : IUserRepository
    {
        private HarperNetClient.IHarperClient _harperClient;
        private ConfigurationHandler configHandler;
        private HarperNetClient.models.HarperDbConfiguration _harperDbConfig;
        private const string Schema_Table = "user";

        public UserRepository(IConfigurationHandler config)
        {
            configHandler = (ConfigurationHandler)config;
            _harperDbConfig = configHandler.GetHarperDbConfiguration();
            _harperClient = new HarperNetClient.HarperClient(_harperDbConfig, Schema_Table);
        }

        public string CreateNewUser(User userToCreate)
        {
            var response = _harperClient.CreateRecord<User>(userToCreate);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Inserted_Hashes[0];
            else
                return JsonConvert.DeserializeObject<HarperNetClient.models.Content>(response.Content).Message;
        }

    }
}
