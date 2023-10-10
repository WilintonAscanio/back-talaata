using Azure.Core;
using backTalaata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backTalaata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return BadRequest("Employee not found");
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            var employee = GetEmployeeById(request.employeeID);

            // Actualiza las propiedades de 'employee' con los valores de 'request'
            _context.Entry(employee).CurrentValues.SetValues(request);

            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
