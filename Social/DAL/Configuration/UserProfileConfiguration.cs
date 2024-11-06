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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UesrProfile>
    {
        public void Configure(EntityTypeBuilder<UesrProfile> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x=>x.FristName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasMany(x => x.Posts).WithOne(x => x.UesrProfiles).HasForeignKey(x => x.UserID);
        }
    }
}
