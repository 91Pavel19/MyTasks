using Microsoft.EntityFrameworkCore;

namespace NewConsolePrelajyha;

public class DatabaseContext : DbContext
{
    public DbSet<Task> Tasks { get; set; } = null!;

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=root");
    }
}