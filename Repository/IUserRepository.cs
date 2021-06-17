using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using harperdb_crud.models;

namespace harperdb_crud.Repository
{
    public interface IUserRepository
    {
        string CreateNewUser(User userToCredte);
    }
}
