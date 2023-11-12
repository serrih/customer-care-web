using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerCare.WebAPI.Data;
using CustomerCare.WebAPI.Models;

namespace CustomerCare.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerCareController : ControllerBase
{
    private readonly ILogger<CustomerCareController> _logger;
    private readonly DataContext _context;

    public CustomerCareController(ILogger<CustomerCareController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetCustomers")]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        return await _context.Customers.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Customer>> Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
            return NotFound();

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return customer;
    }
}