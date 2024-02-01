using Microsoft.EntityFrameworkCore;
using ToDoApplication.Models;

namespace ToDoApplication.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Notes> notes { get; set; }
    }
}
