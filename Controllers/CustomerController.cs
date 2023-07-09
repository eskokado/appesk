using appesk.Repositorties;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace appesk.Controllers;

public class CustomerController : Controller
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IActionResult Index(int page = 1, int pageSize = 1)
    {
        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(page, pageSize);

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
        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(1, 20);
        return PartialView("_CustomerList", customers);
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


    public IActionResult Edit(int id)
    {
        CustomerModel customer = _customerRepository.FindById(id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    [HttpPost]
    public IActionResult Update(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            _customerRepository.Update(customer);
            return RedirectToAction("Index", "Customer");
        }
        else
        {
            return View("Create", customer);
        }
    }

    public IActionResult Delete(int id) 
    {
        if (!_customerRepository.DeleteById(id)) throw new System.Exception("Houve erro na delação de Cliente com id "+id);
        
        return RedirectToAction("Index", new { isFilter = true });
    }

    private List<CustomerModel> GetFilteredCustomersFromDatabase(string name, string email, string phone, DateTime? registrationDate, bool? isBlocked)
    {
        return new List<CustomerModel>();
    }
}
