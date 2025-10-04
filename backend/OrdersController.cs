using Microsoft.AspNetCore.Mvc;

namespace backend; 

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(new { message = "Hola desde mi backend" });
    }
}
