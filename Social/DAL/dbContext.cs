using DAL.Configuration;
using DAL.DataSeed;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dbContext:DbContext
    {
        public dbContext(DbContextOptions options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
            modelBuilder.seedUserProfile();
            modelBuilder.seedPosts();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Post>Posts { get; set; }
        public DbSet<UesrProfile>uesrProfiles { get; set; }
    }
}
