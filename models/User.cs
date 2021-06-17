using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace harperdb_crud.models
{
    public class User
    {
        public User()
        {

        }
        [Key]
        [JsonIgnore]
        public string id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public long ZipCode { get; set; }
    }

}
