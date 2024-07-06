using System.ComponentModel.DataAnnotations;

public class Receivers
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public Message Message { get; set; }
    public int ReceiversId { get; set; }
    public bool isReaded { get; set; }
    public DateTime ReadTime { get; set; }
}