using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_Notes.Models
{
    public class NotesAPIDbContext: IdentityDbContext<IdentityUser>
    {
        public  NotesAPIDbContext(DbContextOptions<NotesAPIDbContext> options)
            : base(options)
        {
           
             Database.EnsureCreated();
           
        }
        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
         
        }

      
    }
}
