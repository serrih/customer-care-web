using Microsoft.EntityFrameworkCore;
using CustomerCare.WebAPI.Data;
using CustomerCare.WebAPI.Models;

public class CustomerCareBackgroundService : BackgroundService
{
    private readonly ILogger<CustomerCareBackgroundService> _logger;
    private readonly IEnumerable<CustomersQueue> customersQueues = new List<CustomersQueue> { 
        new() { Id = 1, AttentionTimeMinutes = 2 }, new() { Id = 2, AttentionTimeMinutes = 3 }
    };
    private readonly IServiceProvider _serviceProvider;

    public CustomerCareBackgroundService(ILogger<CustomerCareBackgroundService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();
            var customers = await context.Customers.ToListAsync(stoppingToken);

            DeleteFromQueueCaredCustomers(context, customers, customersQueues.First(x => x.Id == 1));
            DeleteFromQueueCaredCustomers(context, customers, customersQueues.First(x => x.Id == 2));

            await Task.Delay(1000, stoppingToken);
        }
    }

    private void DeleteFromQueueCaredCustomers(DataContext context, IEnumerable<Customer> customers, CustomersQueue customersQueue)
    {
        customers.Where(customer => customer.QueueNumber == customersQueue.Id)
            .ToList()
            .ForEach(customer => {
                TimeSpan span = DateTime.Now.Subtract(customer.Date);

                if (span.TotalMinutes >= customersQueue.AttentionTimeMinutes)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            });
    }

}