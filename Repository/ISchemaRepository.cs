using System;
namespace harperdb_crud.Repository
{
    public interface ISchemaRepository
    {
        public string CreateTable(string table, string schema);
    }
}
