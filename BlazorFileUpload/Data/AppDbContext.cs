using BlazorFileUpload.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorFileUpload.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions) { }
        public DbSet<Transaction> Transactions {  get; set;  }
    }
}
