using Shedule.Models;
using Shedule.Pages;

namespace Shedule.Data
{
	public interface IPaymentEvent
    {
		public Task AddEvent(PaymentEvent paymentEvent);
		public Task RemoveEvent(int id);
		public Task<IReadOnlyCollection<PaymentEvent>> GetPaymentEvents();
        public Task<IReadOnlyCollection<PaymentEvent>> GetByDate(DateTime date);
        public Task<IReadOnlyCollection<PaymentEvent>> GetByDateInterval(DateTime dateStart, DateTime dateEnd);
        public Task<IReadOnlyCollection<PaymentEvent>> GetByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd);
		public Task<Double>? GetSummByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd);
		public Task<PaymentEvent> GetOneByDate(DateTime date);
        public Task<IReadOnlyCollection<PaymentEvent>> GetByCustomerId(int customerId);
		public Task<PaymentEvent> GetById(int Id);
		public Task<bool> SameExist(int checkId, DateTime checkDate, double checkSumm, string checkText);
		public Task Update(PaymentEvent paymentEvent);
	}
}
