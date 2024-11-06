using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PostTransfer
{
    public class PostDTO
    {
        public int PostID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [ MinLength(3, ErrorMessage = "Must contain 3 or more characters")
         ,MaxLength(12, ErrorMessage = "Must contain 12 or more characters")]
        public string Title { get; set; }
        [Required, MinLength(10, ErrorMessage = "Content cannot be longer than 10-500 characters"), MaxLength(500)]
        public string Content { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime DatedPost { get; set; } = DateTime.Now;
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
