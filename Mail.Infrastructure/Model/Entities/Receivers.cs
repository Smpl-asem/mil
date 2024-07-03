using System.ComponentModel.DataAnnotations;

public class Receivers
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public int ReceiverId { get; set; }
    public bool isReaded { get; set; }
    public DateTime ReadTime { get; set; }
}