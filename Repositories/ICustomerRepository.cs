namespace appesk.Repositorties
{
  public interface ICustomerRepository
  {
    CustomerModel Create(CustomerModel customer);
    List<CustomerModel> GetCustomersFromDatabase(int pageNumber, int pageSize);
  }
}