

using Microsoft.EntityFrameworkCore;
using News.Api.A02._01.News.Models;
using News.Api.A02._01.News.Models.AppIdentity;

namespace News.Api.A02._02.News.ORM
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options) : base(options) { }

        public NewsContext() { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Chanel> Chanel { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<CommentHistory> CommentHistory { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<Praise> Praise { get; set; }
        public DbSet<Newsa> News { get; set; }
        public DbSet<Collection> Collection { get; set; }


    }
}

