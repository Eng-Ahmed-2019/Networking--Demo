using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NetworkingDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("get-header")]
        public IActionResult GetHeader()
        {
            var header = Request.Headers["X-Test"];
            return Ok(new
            {
                Message = "Header Received",
                XTest = header.ToString()
            });
        }

        [HttpGet]
        public IActionResult GetOK()
        {
            return Ok("Hello from Backend");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest("Id must be greater than zero");
            return Ok($"GET by id: \"{id}\"");
        }

        [HttpPost("create-user")]
        public IActionResult Create([FromBody]UserDto user)
        {
            if (user == null) return BadRequest("Invalid request, Please try again");
            return Created("", user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UserDto user)
        {
            if (id <= 0) return BadRequest("Id must be greater than zero");
            if (user == null) return BadRequest("Invalid request, Please try again");
            return Ok("Updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("Id must be greater than zero");
            return Ok("Deleted successfully");
        }
    }

    public class UserDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}