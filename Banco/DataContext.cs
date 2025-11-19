using Microsoft.EntityFrameworkCore;
using MembersMicroservice.Model;

namespace MembersMicroservice.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<MembersModel> MembersModel { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}