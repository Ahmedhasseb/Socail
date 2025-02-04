﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.PostTransfer
{
    public class AddPostDTO
    {
        
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Must contain 3 or more characters")
         , MaxLength(100, ErrorMessage = "Must contain 100 or more characters")]
        public string Title { get; set; }
        [Required, MinLength(10, ErrorMessage = "Content cannot be longer than 10-500 characters"), MaxLength(500)]
        public string Content { get; set; }
       
        public int UserID { get; set; }
    }
}
