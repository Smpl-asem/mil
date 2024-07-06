public class SimpleMessageLog
{
    public int Id { get; set; }
    public int MessageId { get; set; }
    public int UserId { get; set; }
    public int Action { get; set; }
    public DateTime CreateTime { get; set; }
}