using System.ComponentModel.DataAnnotations;

public class MessageLogs
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public Message Message { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Action { get; set; }
    public DateTime CreateTime { get; set; }
}