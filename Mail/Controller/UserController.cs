using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("[Action]")]
[ApiController]
public class UserController:Controller
{
    private IUser us;
    
    public readonly MyFilter _myFilter;
    public UserController(IUser _us,MyFilter myFilter)
    {
        us = _us;
        _myFilter = myFilter;
    }

    [HttpPut]
  
    public IActionResult UpdateData(UpdateUser user){
        return Ok(us.UpdateUsers(user));
    }

    [HttpPut]
  
    public IActionResult ChangePassword(NewPass user){
        return Ok(us.ChangePassword(User.Claims.SingleOrDefault(x=> x.Type == "username").Value ,user));
    }

    [HttpGet]
  
    public IActionResult UserData(int UserId){
        return Ok(us.UserData(UserId));
    }

    [HttpGet]

    public async Task<IActionResult> DataUsers([FromQuery] PaginationFilter filter, [FromQuery] User user)
    {
       try
        {
            //AddLog
            

            if (!ModelState.IsValid)
            {
                return BadRequest(new { status = 400, message = "عملیات با خطا مواجه شد" });
            }

            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = await _myFilter.PerformOperation(user)
               .Include(x=> x.Message)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = pagedData.Count();
            var totalCount = await _myFilter.PerformOperation(user).CountAsync();
            var totalPage = (int)Math.Ceiling(totalCount / (double)validFilter.PageSize);
            return Ok(new PagedResponse<List<User>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalPage, totalCount));
        }
        catch (Exception ex)
        {
            return BadRequest(new { status = 400, message = "عملیات با خطا مواجه شد" + ex.Message });
        }
    }
}