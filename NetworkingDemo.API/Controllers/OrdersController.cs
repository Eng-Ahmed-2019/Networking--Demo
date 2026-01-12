using NetworkingDemo.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace NetworkingDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        // private static List<OrderDto> orders = new List<OrderDto>()
        private static List<OrderDto> orders = new()
        {
            new OrderDto { Id = 1, Name = "Laptop", Price = 15000 },
            new OrderDto { Id = 2, Name = "Mouse", Price = 300 }
        };

        [HttpGet("Get-Orders")]
        public IActionResult GetProducts()
        {
            var o = orders.OrderByDescending(o => o.Id);
            return Ok(o);
        }

        [HttpGet("Get-Order/{id}")]
        public IActionResult GetOrderById(int id)
        {
            if (id <= 0) return BadRequest("Id must be greater than zero");
            var exist = orders.Exists(o => o.Id == id);
            if (!exist) return BadRequest("This order is not exists, please try again");
            var order = orders[id - 1];
            return Ok(order);
        }

        [HttpPost("Create-Order")]
        public IActionResult Create ([FromBody] OrderDto order)
        {
            if (order.Id <= 0) return BadRequest("Id must be greater than zero");
            else if (order.Name == "string") return BadRequest("Invalid name please try again");
            else if (order.Price <= 0) return BadRequest("Price must be greater than zero");
            var exist = orders.Exists(o => o.Id == order.Id);
            if (exist) return BadRequest("This order is exists please try again");
            orders.Add(order);
            return Created("", order);
        }

        [HttpPost("Delete-Order/{id}")]
        public IActionResult Delete (int id)
        {
            if (id <= 0) return BadRequest("Id must be greater than zero");
            var exist = orders.Exists(o => o.Id == id);
            if (!exist) return BadRequest("This order is not exists, please try again");
            var order = orders[id - 1];
            orders.Remove(order);
            return Ok("Deleted successfully");
        }
    }
}