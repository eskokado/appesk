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


    public IPagedList<CustomerModel> ListPerPage(int pageNumber, int pageSize = 20)
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
  }
}

