using datingapp_service.datingapp.data;
using datingapp_service.datingapp.InterfaceRepository;
using datingapp_service.datingapp.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace datingapp_service.datingapp.ClassRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DatingAppDBContext _context;
        public AuthRepository(DatingAppDBContext context)
        {
            _context = context;
        }

        //-----LOGIN---------------
        public User Login(string username, string password)
        {
            var user = _context.tbl_User.FirstOrDefault(x => x.UserName == username);
            
            if (user == null)
            {
                return null;
            }
            if (!VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }


        //-----------------------------register-------------------------------------
        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.tbl_User.Add(user);
            _context.SaveChanges();
            return user;
        }

        //----------------------------------------user Exists---------------------------------------
        public bool UserExists(string username)
        {
            if (_context.tbl_User.Any(x => x.UserName == username))
            {
                return true;
            }
            return false;
        }

        //---------------------------------------Createpassword method----------------------------------------------
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
        //-----------------------------------Verify User Method--------------------------------
        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));     
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
