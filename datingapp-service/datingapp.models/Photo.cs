using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.models
{
    public class Photo
    {
        public int id { get; set; }
        public string photo_url { get; set; }
        public string description { get; set; }
        public DateTime date_added { get; set; }
        public bool is_main_photo { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}