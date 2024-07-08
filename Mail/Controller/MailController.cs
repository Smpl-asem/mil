using Microsoft.AspNetCore.Mvc;

[Route("[action]")]
[ApiController]
public class MailController:Controller
{
    IMail ml ;
    public MailController(IMail _ml)
    {
        ml = _ml;
    }

    [HttpPost]
    public IActionResult addNewMail(NewMail message , int receivers , int cc){
        return Ok(ml.AddNewMail(message , User.Claims.SingleOrDefault(x=> x.Type == "username").Value , receivers , cc));
    }
}