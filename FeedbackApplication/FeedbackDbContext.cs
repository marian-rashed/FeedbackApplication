using FeedbackApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApplication
{
    public class FeedbackDbContext:IdentityDbContext<ApplicationUser>
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> Options):base(Options)
        {
            
        }

       public DbSet<Opinion> Opiniones { get; set; }
    }
}
