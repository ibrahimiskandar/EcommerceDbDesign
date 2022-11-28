using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskForRelation.Data;
using TaskForRelation.DTOs;
using TaskForRelation.Models;
namespace TaskForRelation.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(OrderDTO orderDTO)
        {
            Order order = _context.Orders.FirstOrDefault(x=>x.EmployeeId == orderDTO.EmployeeId && x.ProductId == orderDTO.ProductId);
           
                order = new Order
                {
                    ProductId= orderDTO.ProductId,
                    EmployeeId= orderDTO.EmployeeId,
                    Count=1,
                    CreatedAt= DateTime.UtcNow.AddHours(4)
                };
              await  _context.Orders.AddAsync(order);
              await  _context.SaveChangesAsync();
            
            return Ok();
        }
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_context.Orders.Include(x => x.Product));
        }
    }
}
