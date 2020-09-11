using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace datingapp_service.datingapp.dtos
{
  public class UserRegisterDTO
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    [StringLength(8, MinimumLength =4, ErrorMessage = "Password must be between 4 to 8 characters")]
    public string PassWord { get; set; }
  }
}
