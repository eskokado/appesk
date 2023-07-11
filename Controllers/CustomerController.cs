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
    public IActionResult Create(CustomerModel customer, bool clientValidationFailed)
    {
        if (clientValidationFailed || !ModelState.IsValid) return View("Create", customer);

        _customerRepository.Create(customer);

        TempData["ToastMessage"] = "Cliente criado com sucesso!";
        TempData["ToastType"] = "toast-success";

        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(1, 20);
        return RedirectToAction("Index", customers);
    }


    public IActionResult Edit(int id)
    {
        CustomerModel? customer = _customerRepository.FindById(id);
        if (customer == null) return NotFound();

        return View(customer);
    }

    [HttpPost]
    public IActionResult Update(CustomerModel customer, bool clientValidationFailed)
    {
        if (clientValidationFailed || !ModelState.IsValid) return View("Edit", customer);
        
        TempData["ToastMessage"] = "Cliente alterado com sucesso!";
        TempData["ToastType"] = "toast-success";

        IPagedList<CustomerModel> customers = _customerRepository.ListPerPage(1, 20);
        return RedirectToAction("Index", customers);
    }

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        if (!_customerRepository.DeleteById(id)) throw new System.Exception("Houve erro na delação de Cliente com id "+id);

        TempData["ToastMessage"] = "Cliente deletado com sucesso!";
        TempData["ToastType"] = "toast-success";

        return Ok();
    }

    [HttpPost]
    public IActionResult ValidateEmail(string data, int? id)
    {
        CustomerModel? customerExists = _customerRepository.FindByEmail(data);

        if (customerExists == null) return Ok();

        if (id != null && customerExists.Id == id) return Ok();

        return BadRequest();
    }

    [HttpPost]
    public IActionResult ValidateCpfCnpj(string data, int? id)
    {
        CustomerModel? customerExists = _customerRepository.FindByCpfCnpj(data);

        if (customerExists == null) return Ok();

        if (id != null && customerExists.Id == id) return Ok();

        return BadRequest();
    }

    [HttpPost]
    public IActionResult ValidateStateRegistration(string data, int? id)
    {
        if (data == "") return BadRequest();
        if (data == "ISENTO") return Ok();

        CustomerModel? customerExists = _customerRepository.FindByStateRegistration(data);

        if (customerExists == null) return Ok();

        if (id != null && customerExists.Id == id) return Ok();

        return BadRequest();
    }
}
