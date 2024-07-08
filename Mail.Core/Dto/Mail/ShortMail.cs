public class ShortMail
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public int SenderId { get; set; }
    public List<int> ReceiversId { get; set; }
    public List<int> CarbonCopysId { get; set; }
    public string Subject { get; set; }
    public string BodyText { get; set; }
    public string type { get; set; }
    public DateTime CreatedTime { get; set; }
}