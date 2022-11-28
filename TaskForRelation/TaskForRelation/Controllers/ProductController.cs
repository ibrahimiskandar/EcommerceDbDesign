using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskForRelation.Data;
using TaskForRelation.DTOs;
using TaskForRelation.Models;

namespace TaskForRelation.Controllers
{

    [ApiController]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
           _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductDTO productDTO)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Name == productDTO.Name);
            if (product == null)
            {
                product = new Product
                {
                    Name = productDTO.Name,
                    SalePrice = productDTO.SalePrice,
                    CostPrice = productDTO.CostPrice,
                    CreatedAt = DateTime.Now,
                    Count = productDTO.Count
                };
               await _context.Products.AddAsync(product);
               await _context.SaveChangesAsync();
                return Ok(product);
            }
            return NoContent();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.Include(x => x.Orders));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();
        }
    }
}
