using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using System.Collections.Generic;
using System.Timers;

namespace Shedule.Data
{
	public class SqliteManagersAsync : IManager
	{
		private readonly AppDbContext _dbContext;

		public SqliteManagersAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddManager(Manager manager)
		{
			Manager? selectedManager = await GetByName(manager.ManagerName);
			if (selectedManager == null)
			{
				await _dbContext.Managers.AddAsync(manager);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

		public async Task <IReadOnlyCollection<Manager>> GetManagers()
		{
			var list = await _dbContext.Managers.ToListAsync();
			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<Manager>> GetActiveManagers()
		{
			var list = new List<Manager>();

			var users = _dbContext.Managers.Where(p => p.IsEnable == true);

			foreach (var item in users)
			{
				list.Add(item);
			}

			return list.AsReadOnly();
		}

		public async Task<Manager> GetById(int Id)
		{
			var manager = await _dbContext.Managers.FirstAsync(it => it.Id == Id);
			return manager;
        }

		public async Task<Manager> GetByName(string managerName)
		{
			Manager manager = new Manager();
			manager = await _dbContext.Managers.FirstOrDefaultAsync(it => it.ManagerName == managerName);
			return manager;
        }

		public async Task<Manager> GetAuthorize(string managerName, string password)
		{
			Manager? manager = await GetByName(managerName);
			if (manager == null)
			{
				return null;
			}
			else
			{
				if (manager.ManagerPassword == password)
				{
					return manager;
				}
				else
				{
					return null;
				}
			}
			
		}

		public async Task Update(Manager manager)
		{
			_dbContext.Entry(manager).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
