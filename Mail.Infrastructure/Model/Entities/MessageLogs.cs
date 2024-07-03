using System.ComponentModel.DataAnnotations;

public class MessageLogs
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public int UserId { get; set; }
    public string Action { get; set; }
    public DateTime CreateTime { get; set; }
}