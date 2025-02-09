using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Office.Interop.Outlook;
using Shedule.Models;
using Shedule.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shedule.Data
{
	public class SqlitePaymentEventsAsync : IPaymentEvent
    {
		private readonly AppDbContext _dbContext;

		public SqlitePaymentEventsAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEvent(PaymentEvent paymentEvent)
		{
			await _dbContext.PaymentEvents.AddAsync(paymentEvent);
			await _dbContext.SaveChangesAsync();
		}

		public async Task RemoveEvent(int id)
		{
			var thisEvent = await _dbContext.PaymentEvents.FirstOrDefaultAsync(it => it.Id == id);
			_dbContext.PaymentEvents.Remove(thisEvent);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyCollection<PaymentEvent>> GetPaymentEvents()
		{
			var list = await _dbContext.PaymentEvents.ToListAsync();
			return list.AsReadOnly();
		}
				
		public async Task<IReadOnlyCollection<PaymentEvent>> GetByDate(DateTime date)
		{
			var list = new List<PaymentEvent>();

			var newList = _dbContext.PaymentEvents.Where(p => p.PaymentDate == date);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<PaymentEvent>> GetByDateInterval(DateTime dateStart, DateTime dateEnd)
		{
			var list = new List<PaymentEvent>();

			var newList = _dbContext.PaymentEvents.Where(p => p.PaymentDate >= dateStart && p.PaymentDate <= dateEnd);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

        public async Task<IReadOnlyCollection<PaymentEvent>> GetByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd)
		{
			var list = new List<PaymentEvent>();

			var newList = _dbContext.PaymentEvents.Where(p => p.PaymentDate >= dateStart && p.PaymentDate <= dateEnd && p.CustomerId == customerId);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

		public async Task<Double>? GetSummByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd)
		{
			double thisSum = _dbContext.PaymentEvents.Where(p => p.PaymentDate >= dateStart && p.PaymentDate <= dateEnd && p.CustomerId == customerId)
														.Sum(u => u.PaymentSumm);
			return thisSum;
		}

		public async Task<PaymentEvent> GetOneByDate(DateTime date)
        {
            var thisEvent = await _dbContext.PaymentEvents.FirstAsync(it => it.PaymentDate == date);
            return thisEvent;
        }

        public async Task<IReadOnlyCollection<PaymentEvent>> GetByCustomerId(int customerId)
		{
			var list = new List<PaymentEvent>();

			foreach (var item in _dbContext.PaymentEvents)
			{
				if (item.CustomerId == customerId)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

		public async Task<PaymentEvent> GetById(int Id)
		{
			var thisEvent = await _dbContext.PaymentEvents.FirstAsync(it => it.Id == Id);
			return thisEvent;
		}

		public async Task<bool> SameExist(int checkId, DateTime checkDate, double checkSumm, string checkText)
		{
			var thisEvent = await _dbContext.PaymentEvents.FirstOrDefaultAsync(it => it.CustomerId == checkId && it.PaymentDate == checkDate && it.PaymentSumm == checkSumm && it.PaymentText == checkText);
			if (thisEvent == null)
			{ return false; }
			else	return true;			
		}

		public async Task Update(PaymentEvent paymentEvent)
		{
			_dbContext.Entry(paymentEvent).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
