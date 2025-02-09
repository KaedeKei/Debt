using Shedule.Models;
using Shedule.Pages;

namespace Shedule.Data
{
	public interface ISaleEvent
	{
		public Task AddEvent(SaleEvent saleEvent);
		public Task RemoveEvent(int id);
		public Task<IReadOnlyCollection<SaleEvent>> GetSaleEvents();
        public Task<IReadOnlyCollection<SaleEvent>> GetByDate(DateTime date);
        public Task<IReadOnlyCollection<SaleEvent>> GetByDateInterval(DateTime dateStart, DateTime dateEnd);
        public Task<IReadOnlyCollection<SaleEvent>> GetByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd);
		public Task<Double>? GetSummByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd);
		public Task<SaleEvent>? GetByName(string saleName);
        public Task<IReadOnlyCollection<SaleEvent>> GetByCustomerId(int customerId);
        public Task<IReadOnlyCollection<SaleEvent>> GetByCustomerAndCityId(int customerId, int cityId);
        public Task<SaleEvent> GetById(int Id);
		public Task<bool> SameExist(int checkId, DateTime checkDate, double checkSumm, string checkText, int checkCityId);
		public Task Update(SaleEvent saleEvent);
	}
}
