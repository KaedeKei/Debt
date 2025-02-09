using Shedule.Models;
using System.Threading.Tasks;

namespace Shedule.Data
{
	public interface IManager
	{
		public Task AddManager(Manager manager);
        public Task<IReadOnlyCollection<Manager>> GetManagers();
        public Task<IReadOnlyCollection<Manager>> GetActiveManagers();
		public Task<Manager> GetById(int Id);
		public Task<Manager> GetByName(string managerName);
		public Task<Manager> GetAuthorize(string managerName, string password);
		public Task Update(Manager manager);
	}
}
