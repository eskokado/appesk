using appesk.Repositorties;
using Microsoft.AspNetCore.Mvc;

namespace appesk.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IActionResult Index(bool isFilter = true)
    {
        ViewBag.IsFilter = isFilter;

        List<CustomerModel> customers = _customerRepository.GetCustomersFromDatabase(1, 10); // Obtenha os compradores do banco de dados
        return View(customers);
    }

    [HttpPost]
    public IActionResult Filter(string name, string email, string phone, DateTime? registrationDate, bool? isBlocked)
    {
        List<CustomerModel> filteredCustomers = GetFilteredCustomersFromDatabase(name, email, phone, registrationDate, isBlocked);
        return RedirectToAction("Index", new { isFilter = true });
    }

    [HttpPost]
    public IActionResult ClearFilters()
    {
        List<CustomerModel> customers = _customerRepository.GetCustomersFromDatabase(1, 20);
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

    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            _customerRepository.Create(customer);
            return RedirectToAction("Index", "Customer");
        }
        else
        {
            return View("Create", customer);
        }
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
