using datingapp_service.datingapp.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.InterfaceRepository
{
  public interface IAuthRepository
  {
    User Register(User user, string password);
    User Login(string username, string password);
    bool UserExists(string username);
  }
}
