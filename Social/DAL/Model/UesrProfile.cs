using DAL.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class UesrProfile
    {
        public int UserID { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Post>Posts { get; set; }
        public EnumState State { get; set; }

    }
    
}
