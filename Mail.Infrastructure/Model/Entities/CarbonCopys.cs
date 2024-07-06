using System.ComponentModel.DataAnnotations;

public class CarbonCopys
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public Message Message { get; set; }
    public int CarbonCopysId { get; set; }
    public bool isReaded { get; set; }
    public DateTime ReadTime { get; set; }
}