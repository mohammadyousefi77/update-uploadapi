using FileUpload.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileUpload.Data
{
    public class DbContextClass:DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }


        public DbSet<FileDetails> FileDetails { get; set; }

        public DbSet<Moshakhsat> moshakhsats { get; set; }
    }
}
