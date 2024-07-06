using System.ComponentModel.DataAnnotations;

public class File
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Path { get; set; }
    public DateTime CreateTime { get; set; }
    public bool FlagDelete { get; set; }
}