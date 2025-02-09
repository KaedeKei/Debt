using Shedule.Models;

namespace Shedule.Data
{
	public interface ICustomer
	{
		public Task AddCustomer(Customer customer);
        public Task<IReadOnlyCollection<Customer>> GetCustomers();
        public Task<IReadOnlyCollection<Customer>> GetActiveCustomers();
        public Task<IReadOnlyCollection<Customer>> GetActiveCustomersByCityId(int cityId);
        public Task<IReadOnlyCollection<Customer>?> GetCustomersByName(string customerName);
		public Task<IReadOnlyCollection<Customer>?> GetCustomersByNameOrINN(string wordToSearch);
		public Task<Customer> GetFirstByName(string customerName);
		public Task<Customer> GetById(int id);
        public Task<Customer> GetByINN(string inn);
		public Task<double> GetDebt(int id);
		public Task Update(Customer customer);
	}
}
