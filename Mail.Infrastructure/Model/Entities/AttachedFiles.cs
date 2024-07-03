using System.ComponentModel.DataAnnotations;

public class AttachedFiles
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public int FileId { get; set; }
}