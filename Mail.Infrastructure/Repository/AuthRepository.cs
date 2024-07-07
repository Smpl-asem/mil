using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthRepository : IAuth
{
    private static readonly string salt = "SaL@m In MatN AMniaTi Ma HastesH masalan !"; //سلام این متن امنیتی ما هستش مثلا ! 
    private Context db = new Context();
    public string login(login user)
    {
        User check = db.user_tbl.FirstOrDefault(x=> x.Username == user.Username);
        if(check == null){
            return "Invalid Username";
        }
        else if(!BCrypt.Net.BCrypt.Verify(user.Password+salt+user.Username.ToLower(),check.Password)){
            return "Incorrect Password";
        }
        else{
            return TokenMaker(user.Username.ToLower());
        }

    }
    // public string login(login user){
    //     if(user.Username == "admin" && user.Password == "admin"){
    //         return TokenMaker(user.Username);
    //     }
    //     else{
    //         return "invalid";
    //     }
    // }

    public string Register(Register user)
    {
        if(db.user_tbl.Any(x => x.Phone == user.Phone || x.NationalCode == user.NationalCode)){
            return "You Already Registered";
        }
        else if(db.user_tbl.Any(x => x.Username == user.Username)){
            return "UserName is Not Avalble";
        }
        else{
            User newUser = new User{
                Username = user.Username.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password+salt+user.Username),
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                PersonnalCode = user.PersonnalCode,
                SmsCode = "-1",
                Profile = user.Profile,
                token = "",
                Phone = user.Phone
            };
            db.user_tbl.Add(newUser);
            db.SaveChanges();
            return "Register Successful";
        }
        
    }

    public string ResetPassword(string Username)
    {
        User check = db.user_tbl.FirstOrDefault(x=> x.Username == Username.ToLower());
        if (check == null){
            return "Invalid Username";
        }
        Random random = new Random();
        check.IsCodeValid = true;
        check.SmsCode = $"{random.Next(100000,999999)}";
        db.user_tbl.Update(check);
        db.SaveChanges();

        smsSender(check.Phone,check.SmsCode);
        // return "SMS has been sent";  //Sms Service isn't Run Yet
        return $"SMS has been sent to number {check.Phone} with code {check.SmsCode}";

    }

    public string VeirfyResetPassword(ResetPass user)
    {
        User check = db.user_tbl.FirstOrDefault(x=> x.Username == user.Username.ToLower());
        if (check == null){
            return "Invalid Username";
        }
        else if(!check.IsCodeValid){
            return "Invalid Sms Service , Try Again.";
        }
        else{
            if(check.SmsCode == user.SmsCode){
                check.Password = PassMaker(user.NewPassword , user.Username.ToLower());
                check.IsCodeValid = false;
                db.user_tbl.Update(check);
                db.SaveChanges();
                return "Succesful";
            }
            else{
                check.IsCodeValid = false;
                db.user_tbl.Update(check);
                db.SaveChanges();
                return "Invalid Sms , Try Again.";
            }
        }
    }
    
    public static string PassMaker(string Password , string Username){
        return BCrypt.Net.BCrypt.HashPassword(Password + salt + Username);
    }
    public static bool isPassValid(string Password , string Username , string hash){
        return BCrypt.Net.BCrypt.Verify(Password+salt+Username,hash);
    }

    private void smsSender(string phone , string SmsCode){
        // Code For Sms
        throw new NotImplementedException();
    }

    private string TokenMaker(string Username){
        SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("Zende Bad Bar Shoma Dost azIz ! in matn testi mane"));
        SigningCredentials Credentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256);
        
        Claim[] claims = new Claim[]{
            new Claim("username",Username)
        };

        var token = new JwtSecurityToken(
            issuer: "http://localhost:5110",
            audience: "http://localhost:5110",
            claims: claims,         
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: Credentials
        ); 
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}