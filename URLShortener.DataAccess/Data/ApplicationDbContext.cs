using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using URLShortener.Models;

namespace URLShortener.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        DbSet<UrlItem> UrlItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UrlItem>().HasData(
                new UrlItem { Id = 1, Url = "https://www.youtube.com/watch?v=pQYr1LbVFaM&ab_channel=XGTVUA", CreatedDate = DateTime.Now },
                new UrlItem { Id = 2, Url = "https://open.spotify.com/queue", CreatedDate = DateTime.Now },
                new UrlItem { Id = 3, Url = "https://mail.google.com/mail/u/0/#inbox", CreatedDate = DateTime.Now }
                );
        }
    }
}
