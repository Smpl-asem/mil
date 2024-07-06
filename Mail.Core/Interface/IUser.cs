public interface IUser
{
    public SimpleUser UserData(int userId);
    public List<SimpleUser> UserDatas();
    public string UpdateUsers( UpdateUser user);
    public string ChangePassword(string Username , NewPass user);

}