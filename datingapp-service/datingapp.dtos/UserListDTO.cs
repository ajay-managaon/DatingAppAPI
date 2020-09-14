using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.dtos
{
    public class UserListDTO
    {
        public int user_id { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastActive { get; set; }     
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}
