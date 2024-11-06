using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.PostID);
             builder.Property(x=>x.Content).IsRequired();
            builder.Property(x=>x.Title).IsRequired();
            builder.HasOne(x => x.UesrProfiles).WithMany(x => x.Posts).HasForeignKey(x => x.UserID);
        }
    }
}
