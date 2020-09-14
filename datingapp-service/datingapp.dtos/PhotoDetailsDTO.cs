using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.dtos
{
    public class PhotoDetailsDTO
    {
        public int id { get; set; }
        public string photo_url { get; set; }
        public string description { get; set; }
        public DateTime date_added { get; set; }
        public bool is_main_photo { get; set; }
    }
}
