using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using Shedule.Pages;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shedule.Data
{
	public class SqliteCustomersAsync : ICustomer
	{
		private readonly AppDbContext _dbContext;

		public SqliteCustomersAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddCustomer(Customer customer)
		{
			Customer? newCustomer = await GetByINN(customer.INN);
			if (newCustomer == null)
			{
				await _dbContext.Customers.AddAsync(customer);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

        public async Task<IReadOnlyCollection<Customer>> GetCustomers()
        {
            var list = await _dbContext.Customers.ToListAsync();
            return list.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Customer>> GetActiveCustomers()
        {
            var list = new List<Customer>();
			var newList = _dbContext.Customers.Where(p => p.IsEnable == true);

			foreach (var item in _dbContext.Customers)
            {
                if (item.IsEnable == true)
                {
                    list.Add(item);
                }
            }

            return list.AsReadOnly();
        }

        public async Task<IReadOnlyCollection<Customer>> GetActiveCustomersByCityId(int cityId)
        {
			var list = new List<Customer>();
			var newList = _dbContext.Customers.Where(p => p.IsEnable == true && p.ResponsibleCityId == cityId);

			foreach (var item in newList)
			{
				if (item.IsEnable == true)
				{
					list.Add(item);
				}
			}

			return list.AsReadOnly();
		}

        public async Task<IReadOnlyCollection<Customer>?> GetCustomersByName(string customerName)
		{
			var searchResults = _dbContext.Customers.Where(it => it.CustomerName.Contains(customerName));
			var list = new List<Customer>();
			if (searchResults == null)
			{
				return list;
			}
			else
			{
				foreach (var item in searchResults)
				{
					list.Add(item);
				}

				return list.AsReadOnly();
			}			
		}

		public async Task<IReadOnlyCollection<Customer>?> GetCustomersByNameOrINN(string wordToSearch)
		{
			var searchResults = _dbContext.Customers.Where(it => it.CustomerName.Contains(wordToSearch) || it.INN == wordToSearch);
			var list = new List<Customer>();
			if (searchResults == null)
			{
				return list;
			}
			else
			{
				foreach (var item in searchResults)
				{
					list.Add(item);
				}

				return list.AsReadOnly();
			}
		}

		public async Task<Customer> GetById(int Id)
		{
			var customer = await _dbContext.Customers.FirstAsync(it => it.Id == Id);
			return customer;
        }

        public async Task<Customer> GetByINN(string inn)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(it => it.INN == inn);
            return customer;
        }

        public async Task<Customer> GetFirstByName(string customerName)
		{
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(it => it.CustomerName == customerName);
            return customer;
        }

		public async Task<double> GetDebt(int id)
		{
			double debt = 0;
			var customer = await _dbContext.Customers.FirstAsync(it => it.Id == id);
			int alowed = customer.PaymentDeferment;

			double payments = _dbContext.PaymentEvents.Where(p => p.CustomerId == id)
						.Sum(u => u.PaymentSumm);

			double sales = _dbContext.SaleEvents.Where(p => p.CustomerId == id && p.SaleDate < DateTime.Today.AddDays(-alowed))
						.Sum(u => u.SaleSumm);

			debt = sales - payments;

			return debt;
		}

		public async Task Update(Customer customer)
		{
			_dbContext.Entry(customer).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
