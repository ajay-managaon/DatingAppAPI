using datingapp_service.datingapp.data;
using datingapp_service.datingapp.InterfaceRepository;
using datingapp_service.datingapp.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.ClassRepository
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DatingAppDBContext context;

        public DatingRepository(DatingAppDBContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public User GetUser(int id)
        {
            return context.tbl_User.Include(p => p.Photos).FirstOrDefault(u => u.user_id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return context.tbl_User.Include(p => p.Photos).ToList();
        }

        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}
