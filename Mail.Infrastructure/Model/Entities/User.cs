using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? NationalCode { get; set; }
    public string? PersonnalCode { get; set; }
    public string? Phone { get; set; }
    public string? SmsCode { get; set; }
    public bool? IsCodeValid { get; set; }
    public List<Message>? Message { get; set; }
    public string? Profile { get; set; }
    public string? token { get; set; }
    public DateTime? CreateTime { get; set; }

    public User()
    {
       this.Id=null;
        this.Username=null;
        this.Password=null;
        this.FirstName=null;
        this.LastName=null;
        this.NationalCode=null;
        this.PersonnalCode=null;
        this.Phone=null;
        this.SmsCode=null;
        this.IsCodeValid=null;
        this.Message=null;
        this.Profile=null;
        this.token=null;
        this.CreateTime=null;
        
        
    }
}