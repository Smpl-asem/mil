public class SimpleMessage
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public int SenderId { get; set; }
    public string SenderIp { get; set; }
    public List<int> ReceiversId { get; set; }
    public List<int> CarbonCopysId { get; set; }

    // Text ->
    public string Subject { get; set; }
    public string BodyText { get; set; }
    public List<int> AttachedFilesId { get; set; }
}