using Microsoft.AspNetCore.Mvc;

namespace backend;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static List<Order> Orders = new List<Order>
    {};

    [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(Orders);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Guid == id);
        if (order == null) return NotFound(new { message = "Orden no encontrada" });
        return Ok(order);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
    {
        var newOrder = new Order
        {
            Guid = Orders.Count > 0 ? Orders[^1].Guid + 1 : 1,
            Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
            Nombre = dto.Nombre,
            Total = dto.Total
        };

        Orders.Add(newOrder);
        return Ok(new { message = "Orden creada correctamente", order = newOrder });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, [FromBody] CreateOrderDto dto)
    {
        var order = Orders.FirstOrDefault(o => o.Guid == id);
        if (order == null) return NotFound(new { message = "Orden no encontrada" });

        order.Nombre = dto.Nombre;
        order.Total = dto.Total;
        return Ok(new { message = "Orden actualizada correctamente", order });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Guid == id);
        if (order == null) return NotFound(new { message = "Orden no encontrada" });

        Orders.Remove(order);
        return Ok(new { message = "Orden eliminada correctamente" });
    }
}

public class CreateOrderDto
{
    public string Nombre { get; set; } = string.Empty;
    public int Total { get; set; }
}

// Modelo de orden
public class Order
{
    public int Guid { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Fecha { get; set; } = string.Empty;
    public int Total { get; set; }
}
