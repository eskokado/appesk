using X.PagedList;

namespace appesk.Repositorties
{
	public interface ICustomerRepository
	{
		CustomerModel Create(CustomerModel customer);
		CustomerModel? Update(CustomerModel customer);
		IPagedList<CustomerModel> ListPerPage(int pageNumber, int pageSize);
		IPagedList<CustomerModel> GetFiltered(int pageNumber, int pageSize, string? name, string? email, string? phone, DateTime? registrationDate, bool? isBlocked);
		CustomerModel? FindById(int id);
		CustomerModel? FindByEmail(string email);
		CustomerModel? FindByCpfCnpj(string cpfCnpj);
		CustomerModel? FindByStateRegistration(string stateRegistration);

		bool DeleteById(int id);
	}
}