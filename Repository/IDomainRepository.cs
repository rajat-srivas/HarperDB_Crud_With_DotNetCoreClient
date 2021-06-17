using System;
using System.Collections.Generic;
using harperdb_crud.models;

namespace harperdb_crud.Repository
{
    public interface IDomainRepository
    {
        public List<string> CreateDomainTrackingFromCSV(string filePath);
        public string DeleteDomainById(string id);
        public string UpdateDomain(DomainTracking domain);
        public string CreateDomain(DomainTracking domainToCreate);
    }
}
