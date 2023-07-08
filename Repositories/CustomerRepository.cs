using appesk.Data;
using AutoMapper;

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
		CustomerModel customerUpdate = FindById(customer.Id);

		if (customerUpdate == null) throw new System.Exception("Customer not found with id: " + customer.Id);

		customerUpdate = _mapper.Map<CustomerModel>(customer);

		_databaseContext.Update(customerUpdate);		
      	_databaseContext.SaveChanges();

      	return customerUpdate;
    }


    public List<CustomerModel> ListPerPage(int pageNumber, int pageSize = 20)
    {
        List<CustomerModel> customers = new List<CustomerModel>();

        customers = _databaseContext.Customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return customers;
    }

    public CustomerModel? FindById(int id)
    {
      return _databaseContext.Customers.FirstOrDefault(c => c.Id == id);
    }
  }
}

