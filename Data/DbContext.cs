using Microsoft.EntityFrameworkCore;
using MembersMicroservice.Models;

namespace MembersMicroservice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<MembersModel> Members { get; set; }
    }
}
