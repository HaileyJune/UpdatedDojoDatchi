using Microsoft.EntityFrameworkCore;
using UpdatedLogReg.Models;
using UpdatedDojoDatchi.Models;

namespace UpdatedDojoDatchi.Models
{
    public class MonsterContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MonsterContext(DbContextOptions<MonsterContext> options) : base(options) { }
        public DbSet<UserObject> Users { get; set; }
        public DbSet<MonsterObject> Monsters { get; set; }
    }
}