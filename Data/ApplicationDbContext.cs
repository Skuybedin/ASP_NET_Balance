using Microsoft.EntityFrameworkCore;
using BalanceTest.Models;

namespace BalanceTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CreateUser> CreateUser { get; set; }

        public DbSet<AddBalance> AddBalance { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}