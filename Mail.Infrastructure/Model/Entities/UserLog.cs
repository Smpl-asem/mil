using System.ComponentModel.DataAnnotations;

public class UserLog
{
    [Key]
    public int Id { get; set; }
    public int Creator { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public DateTime CreateTime { get; set; }
}