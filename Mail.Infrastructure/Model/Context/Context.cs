using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{
    public DbSet<User> user_tbl { get; set; }
    public DbSet<UserLog> userLog_tbl { get; set; }
    public DbSet<CarbonCopys> CarbonCopys_tbl { get; set; }
    public DbSet<Files> File_tbl { get; set; }
    public DbSet<AttachedFile> AttachedFile_tbl { get; set; }
    public DbSet<Message> Message_tbl { get; set; }
    public DbSet<MessageLogs> MessageLogs_tbl { get; set; }
    public DbSet<Receivers> Receivers_tbl { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=matterhorn.liara.cloud,31803;Initial Catalog=testMail1;User Id=sa;Password=LATgw22EGzAbfgyS41IeWR7L;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}