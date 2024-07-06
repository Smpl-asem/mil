using Microsoft.AspNetCore.Mvc;
[Route("[Action]")]
[ApiController]
public class UserController:Controller
{
    private IUser us;
    public UserController(IUser _us)
    {
        us = _us;
    }

    [HttpPut]
    public IActionResult UpdateData(UpdateUser user){
        return Ok(us.UpdateUsers(user));
    }

    [HttpPut]
    public IActionResult ChangePassword(NewPass user){
        // return Ok(us.ChangePassword(User.Claims.FirstOrDefault(x=> x.Type == "username").Value ,user));
        return Ok(User.Claims.FirstOrDefault(x=> x.Type == "username").Value);
    }

    [HttpGet]
    public IActionResult UserData(int UserId){
        return Ok(us.UserData(UserId));
    }

    [HttpGet]
    public IActionResult UserDatas(){
        return Ok(us.UserDatas);
    }
}