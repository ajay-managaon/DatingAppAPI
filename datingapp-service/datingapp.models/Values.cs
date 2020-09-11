using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.models
{
    public class Values
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
