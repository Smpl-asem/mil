using System.ComponentModel.DataAnnotations;

public class AttachedFile
{
    [Key]
    public int Id { get; set; }
    public int MessageId { get; set; }
    public Message Message { get; set; }
    public int FilesId { get; set; }
    public Files Files { get; set; }
}