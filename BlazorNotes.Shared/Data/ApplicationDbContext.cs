using BlazorNotes.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options) { }
        
         public DbSet<Note> Notes {  get; set; }       
        
    }
}
