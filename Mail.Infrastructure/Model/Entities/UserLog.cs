using System.ComponentModel.DataAnnotations;

public class UserLog
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User user { get; set; }
    public string Action { get; set; }
    public DateTime CreateTime { get; set; }
}