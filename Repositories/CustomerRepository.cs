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
  }
}