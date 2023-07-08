using appesk.Data;

namespace appesk.Repositorties
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly DatabaseContext _databaseContext;
    public CustomerRepository(DatabaseContext databaseContext)
    {
      _databaseContext = databaseContext;
    }

    public CustomerModel Create(CustomerModel customer)
    {
      _databaseContext.Customers.Add(customer);
      _databaseContext.SaveChanges();

      return customer;
    }


    public List<CustomerModel> GetCustomersFromDatabase(int pageNumber, int pageSize = 20)
    {
        List<CustomerModel> customers = new List<CustomerModel>();

        customers = _databaseContext.Customers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return customers;
    }
  }
}