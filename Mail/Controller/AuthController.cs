using Microsoft.AspNetCore.Mvc;

[Route("[Action]")]
[ApiController]
public class AuthController:Controller
{
    private IAuth au;
    public AuthController(IAuth _au)
    {
        au = _au;
    }

    [HttpPost]
    public IActionResult Register(Register user){
        return Ok(au.Register(user));
    }

    [HttpPost]
    public IActionResult Login(login user){
        return Ok(au.login(user));
    }
    
    [HttpPost]
    public IActionResult ResetPassword(string Username){
        return Ok(au.ResetPassword(Username));
    }
    
    [HttpPut]
    public IActionResult VerfyResetPassword(ResetPass user){
        return Ok(au.VeirfyResetPassword(user));
    }

}