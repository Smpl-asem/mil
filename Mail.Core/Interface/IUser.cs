public interface IUser
{
    public SimpleUser UserData();
    public string UpdateUser(UpdateUser user);
    public string ChangePassword(NewPass user);

}