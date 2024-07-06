using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult UpdateData(UpdateUser user){
        return Ok(us.UpdateUsers(user));
    }

    [HttpPut]
    [Authorize]
    public IActionResult ChangePassword(NewPass user){
        return Ok(us.ChangePassword(User.Claims.SingleOrDefault(x=> x.Type == "username").Value ,user));
        // return Ok(User.Claims.FirstOrDefault(x=> x.Type == "username").Value);
    }

    [HttpGet]
    [Authorize]
    public IActionResult UserData(int UserId){
        return Ok(us.UserData(UserId));
    }

    [HttpGet]
    // [Authorize]
    public IActionResult UserDatas(){
        return Ok(us.UserDatas());
    }
}