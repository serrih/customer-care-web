using CustomerCare.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CustomerCare.MVC.Views.Home.Components;

public class CustomersQueueViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int queueNumber) 
    {
        var customersQueue = new Tuple<int, IEnumerable<Customer>>(queueNumber, new List<Customer>());
        
        using var httpClient = new HttpClient();

        string url = "http://localhost:5148/CustomerCare";
        var response = await httpClient.GetAsync(url);
        var result = response.Content.ReadAsStringAsync().Result;
        var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(result);

        if (customers != null)
        {
            var selectedCustomers = customers.Where(customer => customer.QueueNumber == queueNumber);
            customersQueue = new Tuple<int, IEnumerable<Customer>>(queueNumber, selectedCustomers);
        }

        return View(customersQueue);
    }
}