using appesk.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

