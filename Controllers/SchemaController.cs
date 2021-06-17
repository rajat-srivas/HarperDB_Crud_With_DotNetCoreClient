using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using harperdb_crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harperdb_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchemaController : ControllerBase
    {
        ISchemaRepository _domainRepo;
        public SchemaController(ISchemaRepository repo)
        {
            _domainRepo = repo;
        }

        [HttpPost]
        [Route("table")]
        public IActionResult CreateTable(string table, string schema)
        {
            var response = _domainRepo.CreateTable(table, schema);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }

    }
}