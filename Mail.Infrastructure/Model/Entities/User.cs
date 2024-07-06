using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string PersonnalCode { get; set; }
    public string Phone { get; set; }
    public string SmsCode { get; set; }
    public bool IsCodeValid { get; set; }
    public string Profile { get; set; }
    public string token { get; set; }
    public DateTime CreateTime { get; set; }
}