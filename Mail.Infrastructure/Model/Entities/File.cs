using System.ComponentModel.DataAnnotations;

public class Files
{
    [Key]
    public int Id { get; set; }
    public int Creator { get; set; }
    public string Path { get; set; }
    public DateTime CreateTime { get; set; }
}