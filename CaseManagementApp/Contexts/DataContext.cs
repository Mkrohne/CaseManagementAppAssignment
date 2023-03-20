using CaseManagementApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementApp.Contexts
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\macka\Desktop\Win22\dotnet\SQL\datalagring\Assignment\CaseManagementApp\CaseManagementApp\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       


        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<UserEntity> Users { get; set; } = null!;
    }
}