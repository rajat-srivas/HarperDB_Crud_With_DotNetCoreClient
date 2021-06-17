using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using harperdb_crud.models;
using harperdb_crud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace harperdb_crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userStock;
        public UserController(IUserRepository userStcok)
        {
            _userStock = userStcok;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateUser(User userToCreate)
        {
            var response = _userStock.CreateNewUser(userToCreate);
            return response != null ? Ok(response) : BadRequest("Something went wrong");
        }

    }



}