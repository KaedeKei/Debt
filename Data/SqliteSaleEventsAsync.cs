using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shedule.Models;
using Shedule.Pages;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shedule.Data
{
	public class SqliteSaleEventsAsync : ISaleEvent
	{
		private readonly AppDbContext _dbContext;

		public SqliteSaleEventsAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddEvent(SaleEvent saleEvent)
		{
			await _dbContext.SaleEvents.AddAsync(saleEvent);
			await _dbContext.SaveChangesAsync();
		}

		public async Task RemoveEvent(int id)
		{
			var thisEvent = await _dbContext.SaleEvents.FirstOrDefaultAsync(it => it.Id == id);
			_dbContext.SaleEvents.Remove(thisEvent);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<IReadOnlyCollection<SaleEvent>> GetSaleEvents()
		{
			var list = await _dbContext.SaleEvents.ToListAsync();
			return list.AsReadOnly();
		}
				
		public async Task<IReadOnlyCollection<SaleEvent>> GetByDate(DateTime date)
		{
			var list = new List<SaleEvent>();

			var newList = _dbContext.SaleEvents.Where(p => p.SaleDate == date);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

        public async Task<IReadOnlyCollection<SaleEvent>> GetByDateInterval(DateTime dateStart, DateTime dateEnd)
		{
			var list = new List<SaleEvent>();

			var newList = _dbContext.SaleEvents.Where(p => p.SaleDate >= dateStart && p.SaleDate <= dateEnd);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();


		}

        public async Task<IReadOnlyCollection<SaleEvent>> GetByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd)
		{
			var list = new List<SaleEvent>();

			var newList = _dbContext.SaleEvents.Where(p => p.SaleDate >= dateStart && p.SaleDate <= dateEnd && p.CustomerId == customerId);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

		public async Task<Double>? GetSummByDateIntervalAndCustomer(int customerId, DateTime dateStart, DateTime dateEnd)
		{
			double thisSum = _dbContext.SaleEvents.Where(p => p.SaleDate >= dateStart && p.SaleDate <= dateEnd && p.CustomerId == customerId)
														.Sum(u => u.SaleSumm);
			return thisSum;
		}

		public async Task<SaleEvent>? GetByName(string saleName)
        {
            var thisEvent = await _dbContext.SaleEvents.FirstOrDefaultAsync(it => it.SaleName == saleName);
            return thisEvent;
        }

        public async Task<IReadOnlyCollection<SaleEvent>> GetByCustomerId(int customerId)
		{
			var list = new List<SaleEvent>();

			var newList = _dbContext.SaleEvents.Where(p => p.CustomerId == customerId);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

        public async Task<IReadOnlyCollection<SaleEvent>> GetByCustomerAndCityId(int customerId, int cityId)
        {
			var list = new List<SaleEvent>();

			var newList = _dbContext.SaleEvents.Where(p => p.CustomerId == customerId && p.SaleCityId == cityId);

			foreach (var item in newList)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

        public async Task<SaleEvent> GetById(int Id)
		{
			var thisEvent = await _dbContext.SaleEvents.FirstAsync(it => it.Id == Id);
			return thisEvent;
		}

		public async Task<bool> SameExist(int checkId, DateTime checkDate, double checkSumm, string checkText, int checkCityId)
		{
			var thisEvent = await _dbContext.SaleEvents.FirstOrDefaultAsync(it => it.CustomerId == checkId && it.SaleDate == checkDate && it.SaleSumm == checkSumm && it.SaleName == checkText && it.SaleCityId == checkCityId);
			if (thisEvent == null)
			{ return false; }
			else return true;
		}

		public async Task Update(SaleEvent saleEvent)
		{
			_dbContext.Entry(saleEvent).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
