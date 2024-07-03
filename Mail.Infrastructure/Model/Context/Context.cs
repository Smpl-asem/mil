using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{
    public DbSet<User> user_tbl { get; set; }
    public DbSet<UserLog> userLog_tbl { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Skills39~!");
    }
}