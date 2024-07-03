public interface IAuth
{
    public string login(login user);
    public string Register(Register user);
    public string ResetPassword(string Username);
    public string VeirfyResetPassword(ResetPass user);

}