using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataSeed
{
    public static class ModelBuilderExtensions
    {
        public static void seedUserProfile(this ModelBuilder builder)
        {
            builder.Entity<UesrProfile>().HasData(
    new UesrProfile { UserID = 1, FristName = "Ahmed", LastName = "Mohamed", Email = "ahmedhasseb310@gmail.com", DateOfBirth = new DateTime(1999, 2, 22) },
    new UesrProfile { UserID = 2, FristName = "Mohamed", LastName = "Alaa", Email = "MohamedAlaa12@gmail.com", DateOfBirth = new DateTime(1999, 7, 10) },
    new UesrProfile { UserID = 3, FristName = "Ali", LastName = "Ahmed", Email = "AliMohamed@gmail.com", DateOfBirth = new DateTime(1999, 6, 22) },
    new UesrProfile { UserID = 4, FristName = "Yasser", LastName = "Ali", Email = "YaserAli10@gmail.com", DateOfBirth = new DateTime(1999, 9, 9) },
    new UesrProfile { UserID = 5, FristName = "Manar", LastName = "Mohamed", Email = "ManarMohamed311@gmail.com", DateOfBirth = new DateTime(2000, 2, 22) },
    new UesrProfile { UserID = 6, FristName = "Sara", LastName = "Ahmed", Email = "saraAhmedOficial@gmail.com", DateOfBirth = new DateTime(2001, 7, 22) },
    new UesrProfile { UserID = 7, FristName = "Ibrahim", LastName = "Hesham", Email = "HemaHesham40@gmail.com", DateOfBirth = new DateTime(1995, 3, 9) },
    new UesrProfile { UserID = 8, FristName = "Esraa", LastName = "Mostafa", Email = "esraaMostafa55@gmail.com", DateOfBirth = new DateTime(1992, 4, 1) },
    new UesrProfile { UserID = 9, FristName = "Zeyad", LastName = "Adel", Email = "ZeyadAdel665@gmail.com", DateOfBirth = new DateTime(2005, 10, 16) }
);
        }
        public static void seedPosts(this ModelBuilder builder)
        {
            builder.Entity<Post>().HasData
                (
                new Post {PostID=1, Title="interduction1",Content= "English texts for beginners to practice reading",UserID=1,DatedPost=DateTime.Now },
                new Post {PostID=2, Title="interduction1", Content = "English texts for beginners to practice reading",UserID=1,DatedPost=DateTime.Now },
                new Post {PostID=3, Title="interductionTwo", Content = "English texts for beginners to practice reading",UserID=2,DatedPost=DateTime.Now },
                new Post {PostID=4, Title="interductionTwo", Content = "English texts for beginners to practice reading",UserID=2,DatedPost=DateTime.Now },
                new Post {PostID=5, Title="interductionThree", Content = "English texts for beginners to practice reading",UserID=3,DatedPost=DateTime.Now },
                new Post {PostID=6, Title="interductionFor", Content = "English texts for beginners to practice reading",UserID=4,DatedPost=DateTime.Now },
                new Post {PostID=7, Title="interductionFive", Content = "English texts for beginners to practice reading",UserID=5,DatedPost=DateTime.Now },
                new Post {PostID=8, Title="interductionSix", Content = "English texts for beginners to practice reading",UserID=6,DatedPost=DateTime.Now },
                new Post {PostID=9, Title="interductionSix", Content = "English texts for beginners to practice reading",UserID=6,DatedPost=DateTime.Now },
                new Post {PostID=10,Title="interductionSeven", Content = "English texts for beginners to practice reading",UserID=7,DatedPost=DateTime.Now },
                new Post {PostID=11,Title="interductionEight", Content = "English texts for beginners to practice reading",UserID=8,DatedPost=DateTime.Now },
                new Post {PostID=12,Title="interductionNiNe", Content = "English texts for beginners to practice reading",UserID=9,DatedPost=DateTime.Now },
                new Post {PostID=13,Title = "interductionNine", Content = "English texts for beginners to practice reading", UserID = 9, DatedPost = DateTime.Now }

                );
        }
    }
}
