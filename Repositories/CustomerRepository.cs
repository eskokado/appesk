using appesk.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
namespace appesk.Repositorties
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly DatabaseContext _databaseContext;
	private readonly IMapper _mapper;
    public CustomerRepository(DatabaseContext databaseContext, IMapper mapper)
    {
      _databaseContext = databaseContext;
	  _mapper = mapper;
    }

    public CustomerModel Create(CustomerModel customer)
    {
      _databaseContext.Customers.Add(customer);
      _databaseContext.SaveChanges();

      return customer;
    }

    public CustomerModel Update(CustomerModel customer)
    {
        CustomerModel customerUpdate = _databaseContext.Customers.FirstOrDefault(c => c.Id == customer.Id);

        if (customerUpdate == null)
        {
            throw new System.Exception("Cliente não encontrado com o ID: " + customer.Id);
        }

        _databaseContext.Entry(customerUpdate).State = EntityState.Detached;

        _databaseContext.Update(customer);

        _databaseContext.SaveChanges();

        return customer;
    }


	public IPagedList<CustomerModel> ListPerPage(int pageNumber, int pageSize)
	{
		IPagedList<CustomerModel> customers = _databaseContext.Customers.ToPagedList(pageNumber, pageSize);

		return customers;
	}

    public CustomerModel? FindById(int id)
    {
      return _databaseContext.Customers.FirstOrDefault(c => c.Id == id);
    }

    public bool DeleteById(int id) 
    {
      var customerFound = _databaseContext.Customers.FirstOrDefault(c => c.Id == id);

      if (customerFound == null) throw new System.Exception("Customer Not found with id: " + id);

      _databaseContext.Remove(customerFound);
      _databaseContext.SaveChanges();

      return true;
    }

    public IPagedList<CustomerModel> GetFiltered(int pageNumber = 1, int pageSize = 20, string? name = null, string?  email = null, string? phone = null, DateTime? registrationDate = null, bool? isBlocked = null)
    {
		IQueryable<CustomerModel> query = _databaseContext.Customers;

		if (!string.IsNullOrEmpty(name))
		{
			query = query.Where(c => c.Name.Contains(name));
		}

		if (!string.IsNullOrEmpty(email))
		{
			query = query.Where(c => c.Email.Contains(email));
		}

		if (!string.IsNullOrEmpty(phone))
		{
			query = query.Where(c => c.Phone.Contains(phone));
		}

		if (registrationDate.HasValue)
		{
			query = query.Where(c => c.RegistrationDate == registrationDate.Value);
		}

		if (isBlocked.HasValue)
		{
			query = query.Where(c => c.IsBlocked == isBlocked.Value);
		}

		IPagedList<CustomerModel> customers = query.ToPagedList(pageNumber, pageSize);

		return customers;
    }
  }
}

