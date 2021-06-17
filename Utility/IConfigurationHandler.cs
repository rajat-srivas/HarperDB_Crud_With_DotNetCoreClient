using System;
using harperdb_crud.models;

namespace harperdb_crud.Utility
{
    public interface IConfigurationHandler
    {
        HarperNetClient.models.HarperDbConfiguration GetHarperDbConfiguration();
    }
}
