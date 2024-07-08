public class IdMail
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public int SenderId { get; set; }
    public string SenderIp { get; set; }
    public List<int> ReceiversId { get; set; }
    public List<int> CarbonCopysId { get; set; }
    public int FlagDelete { get; set; } // 1.Normal / 2.Trash / 3.Delete
    public List<int> MessageLogsId { get; set; }
    public List<int> MyProperty { get; set; }
    // Text ->
    public string Subject { get; set; }
    public string BodyText { get; set; }
    public List<int> AttachedFilesId { get; set; }
}