using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskForRelation.Data;
using TaskForRelation.DTOs;
using TaskForRelation.Models;

namespace TaskForRelation.Controllers
{
    [ApiController]
    [Route("employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
           _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Fullname == employeeDTO.Fullname && x.Birthdate == employeeDTO.Birthdate);
            if (employee == null)
            {
                employee = new Employee
                {
                    Fullname = employeeDTO.Fullname,
                    Birthdate = employeeDTO.Birthdate
                };
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Employees);
        }
        [HttpGet("id")]
        public IActionResult GetElementById(int id)
        {
            Employee entity = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (entity != null)
                return Ok(entity);
            else
                return NotFound();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return Ok(employee);
            }
            else
                return NotFound();
        }
    }
}
