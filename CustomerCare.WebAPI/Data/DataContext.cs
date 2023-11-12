using Microsoft.EntityFrameworkCore;
using CustomerCare.WebAPI.Models;

namespace CustomerCare.WebAPI.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers { get; set; }
}