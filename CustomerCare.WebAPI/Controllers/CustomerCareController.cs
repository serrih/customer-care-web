using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerCare.WebAPI.Data;
using CustomerCare.WebAPI.Models;
using QueuesDispatcherLibrary;

namespace CustomerCare.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerCareController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<CustomerCareController> _logger;

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
    public async Task<ActionResult> Post(int id, string name)
    {
        var customers = _context.Customers;
        var fasterQueueNumber = QueuesDispatcher.CalculateFasterQueue(GetCustomersByQueue(customers));
        var customer = new Customer { Id = id, Name = name, Date = DateTime.Now, QueueNumber = fasterQueueNumber };

        customers.Add(customer);
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

    private static IEnumerable<Tuple<short, int>> GetCustomersByQueue(IEnumerable<Customer> customers) => customers
            .GroupBy(x => x.QueueNumber)
            .Select(y => new Tuple<short, int>(y.First().QueueNumber, y.Count()))
            .ToList();
}