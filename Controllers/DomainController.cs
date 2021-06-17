using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using harperdb_crud.models;
using harperdb_crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harperdb_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomainController : ControllerBase
    {
        IDomainRepository _domainRepo;
        public DomainController(IDomainRepository repo)
        {
            _domainRepo = repo;
        }

       
        [HttpPost]
        [Route("domain/bulk")]
        public IActionResult CreateDomainFromcsv(string filePath)
        {
            var response = _domainRepo.CreateDomainTrackingFromCSV(filePath);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("domain")]
        public IActionResult CreateDomain(DomainTracking domainToCreate)
        {
            var response = _domainRepo.CreateDomain(domainToCreate);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }

        [HttpDelete]
        [Route("domain/id")]
        public IActionResult CreateDomain(string id)
        {
            var response = _domainRepo.DeleteDomainById(id);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }

        [HttpPut]
        [Route("domain/id")]
        public IActionResult CreateDomain(string id, DomainTracking domainToCreate)
        {
            domainToCreate.id = id;
            var response = _domainRepo.UpdateDomain(domainToCreate);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }
    }
}