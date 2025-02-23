using System.ComponentModel.DataAnnotations;

public class Message
{
    // Head ->
    [Key]
    public int Id { get; set; }
    public DateTime CreateTime { get; set; }
    public string SerialNumber { get; set; }
    public int SenderId { get; set; }
    public User User { get; set; }
    public string SenderIp { get; set; }
    // public List<int> ReceiversId { get; set; }
    public List<Receivers> Receivers { get; set; }
    // public List<int> CarbonCopysId { get; set; }
    public List<CarbonCopys> CarbonCopys { get; set; }
    public int FlagDelete { get; set; } // 1.Normal / 2.Trash / 3.Delete
    // public List<int> MessageLogsId { get; set; } (generic type)
    public List<MessageLogs> MessageLogs { get; set; }
    public List<int> ConnectedUser { get; set; }

    // Text ->
    public string Subject { get; set; }
    public string BodyText { get; set; }
    // public List<int> AttachedFileId { get; set; }
    public List<AttachedFile> AttachedFile { get; set; }
}