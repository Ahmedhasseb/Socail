using DAL.Model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatedPost { get; set; }= DateTime.Now;
        public int UserID {  get; set; }
        public virtual UesrProfile UesrProfiles { get; set; }
        public EnumState State { get; set; }
    }
}
