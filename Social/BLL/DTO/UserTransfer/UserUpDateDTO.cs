using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.DTO.UserTransfer
{
    public class UserUpDateDTO
    {

        [Required(ErrorMessage = "firstName is Required")
          , MinLength(3, ErrorMessage = "Must contain 3 or more characters")
          , MaxLength(12, ErrorMessage = "Must contain 12 or more characters")]
        public string FristName { get; set; }
        [Required(ErrorMessage = "LastName is Required"),
            MinLength(3, ErrorMessage = "Must contain 3 or more characters")
            , MaxLength(12, ErrorMessage = "Must contain 12 or more characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        

    }
}
