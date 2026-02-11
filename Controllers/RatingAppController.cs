using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RatingAppController : ControllerBase
{
    [HttpPost]
    public IActionResult SaveRatingApp(RatingAppForm form)
    {
        return Ok(new { message = "Rating App form received", data = form });
    }
}
