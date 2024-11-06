using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.UserTransfer
{
    public class AddUserDTO
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
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DateOfBirth { get; set; }
    }
}
