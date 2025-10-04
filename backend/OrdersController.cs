using Microsoft.AspNetCore.Mvc;

namespace backend;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = new[]
        {
            new { guid = 1, nombre = "Bryant Tejeda", fecha = "12 de diciembre", total = 100 },
            new { guid = 2, nombre = "Carlos Pérez", fecha = "13 de diciembre", total = 200 },
            new { guid = 3, nombre = "Carlos Pérez", fecha = "14 de diciembre", total = 200 },
            new { guid = 4, nombre = "Carlos Pérez", fecha = "15 de diciembre", total = 200 }
        };


        return Ok(orders);
    }
}
