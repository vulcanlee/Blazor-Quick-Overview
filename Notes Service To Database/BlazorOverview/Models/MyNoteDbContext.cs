using Microsoft.EntityFrameworkCore;

namespace BlazorOverview.Models
{
    public class MyNoteDbContext : DbContext
    {
        public MyNoteDbContext(DbContextOptions<MyNoteDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyNote> MyNotes { get; set; }
    }
}
