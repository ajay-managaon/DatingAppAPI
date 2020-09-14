using datingapp_service.datingapp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.InterfaceRepository
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T : class; // Creating a Generic class to Add Photo and Add User both.
        void Delete<T>(T entity) where T : class;
        bool SaveAll();
        IEnumerable<User> GetUsers();
        User GetUser(int id);
    }
}
