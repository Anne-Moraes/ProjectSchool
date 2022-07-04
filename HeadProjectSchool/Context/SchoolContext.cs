using Microsoft.EntityFrameworkCore;
using HeadProjectSchool.Model;

namespace HeadProjectSchool.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<Team> Team { get; set; }
    }
}
