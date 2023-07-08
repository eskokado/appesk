using Microsoft.AspNetCore.Mvc;

namespace appesk.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        List<CustomerModel> customers = GetCustomersFromDatabase(); // Obtenha os compradores do banco de dados
        return View(customers);
    }

    [HttpPost]
    public IActionResult Filter(string name, string email, string phone, DateTime? registrationDate, bool? isBlocked)
    {
        List<CustomerModel> filteredCustomers = GetFilteredCustomersFromDatabase(name, email, phone, registrationDate, isBlocked);
        return PartialView("_CustomerList", filteredCustomers);
    }

    [HttpPost]
    public IActionResult ClearFilters()
    {
        List<CustomerModel> customers = GetCustomersFromDatabase();
        return PartialView("_CustomerList", customers);
    }

    public IActionResult Edit(int id)
    {
        CustomerModel customer = GetCustomerByIdFromDatabase(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    private List<CustomerModel> GetCustomersFromDatabase()
    {
        return new List<CustomerModel>();
    }

    private List<CustomerModel> GetFilteredCustomersFromDatabase(string name, string email, string phone, DateTime? registrationDate, bool? isBlocked)
    {
        return new List<CustomerModel>();
    }

    private CustomerModel GetCustomerByIdFromDatabase(int id)
    {
        return null;
    }
}
