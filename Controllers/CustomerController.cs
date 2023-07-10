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

    public IActionResult Index(int page = 1, int pageSize = 20)
    {
        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(page, pageSize);

        return View(customers);
    }

    [HttpPost]
    public IActionResult Filter(string name, string email, string phone, DateTime? registrationDate, bool? isBlocked)
    {
        IPagedList<CustomerModel> filteredCustomers = _customerRepository.GetFiltered(1, 20, name, email, phone, registrationDate, isBlocked);
        return View("Index", filteredCustomers);
    }

    [HttpPost]
    public IActionResult ClearFilters()
    {
        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(1, 20);
        return View("Index", customers);
    }

    public IActionResult Create() 
    {
        var customer = new CustomerModel();
        return View(customer);
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

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        if (!_customerRepository.DeleteById(id)) throw new System.Exception("Houve erro na delação de Cliente com id "+id);
        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(1, 20);
        return View("Index", customers);
    }

    [HttpPost]
    public IActionResult ValidateEmail(string data)
    {
        bool isValid = false;

        CustomerModel customerExists = _customerRepository.FindByEmail(data);

        if (customerExists == null) isValid = true;

        if (isValid)
        {
            return Ok(); // O email é válido
        }
        else
        {
            return BadRequest(); // O email é inválido
        }
    }

    [HttpPost]
    public IActionResult ValidateCpfCnpj(string data)
    {
        bool isValid = false;

        CustomerModel customerExists = _customerRepository.FindByCpfCnpj(data);

        if (customerExists == null) isValid = true;

        if (isValid)
        {
            return Ok(); // O email é válido
        }
        else
        {
            return BadRequest(); // O email é inválido
        }
    }
}
