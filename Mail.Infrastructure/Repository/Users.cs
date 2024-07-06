
public class Users : IUser
{
    private Context db = new Context();
    public string ChangePassword(string Username , NewPass user)
    {
        User check = db.user_tbl.FirstOrDefault(x=>x.Username==Username);
        if(Auth.isPassValid(user.OldPassword , Username , check.Password)){
            check.Password = Auth.PassMaker(user.NewPassword,Username);
            db.user_tbl.Update(check);
            db.SaveChanges();
            return "Succesful";
        }
        else{
            return "Invalid Password";
        }
    }

    public string UpdateUsers(UpdateUser user)
    {
        User check = db.user_tbl.FirstOrDefault(x=> x.Username==user.Username);
        check.Phone = user.Phone;
        check.Profile = user.Profile;
        db.user_tbl.Update(check);
        db.SaveChanges();
        return "Succesful";
    }

    public SimpleUser UserData(int userId)
    {
        User check = db.user_tbl.Find(userId);
        if(check == null){
            return new SimpleUser();
        }
        return UserToSimple(check);
    }

    public List<SimpleUser> UserDatas()
    {
        List<SimpleUser> result = new List<SimpleUser>();
        foreach (User item in db.user_tbl)
        {
            result.Add(UserToSimple(item));
        }
        return result;
    }

    private SimpleUser UserToSimple(User check){
        return new SimpleUser{
            Id = check.Id,
            Username = check.Username,
            FirstName = check.FirstName,
            LastName = check.LastName,
            NationalCode = check.NationalCode,
            PersonnalCode = check.PersonnalCode,
            Phone = check.Phone,
            Profile = check.Profile
        };
    }
}