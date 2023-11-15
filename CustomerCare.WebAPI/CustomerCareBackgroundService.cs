using Microsoft.EntityFrameworkCore;
using CustomerCare.WebAPI.Data;
using CustomerCare.WebAPI.Models;

public class CustomerCareBackgroundService : BackgroundService
{
    private readonly ILogger<CustomerCareBackgroundService> _logger;
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
            var customers = await context.Customers.ToListAsync();

            DeleteFromQueueCaredCustomers(context, customers, 1);
            DeleteFromQueueCaredCustomers(context, customers, 2);

            await Task.Delay(1000, stoppingToken);
        }
    }

    private void DeleteFromQueueCaredCustomers(DataContext context, IEnumerable<Customer> customers, short queueNumber)
    {
        customers.Where(customer => customer.QueueNumber == queueNumber)
            .ToList()
            .ForEach(customer => {
                TimeSpan span = DateTime.Now.Subtract(customer.Date);

                if (span.TotalMinutes >= 2)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            });
    }

}