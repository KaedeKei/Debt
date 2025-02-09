using Shedule.Models;

namespace Shedule.Data
{
	public interface ICity
    {
		public Task AddCity(City city);
		Task<IReadOnlyCollection<City>> GetCities();
		Task<IReadOnlyCollection<City>> GetCitiesByName(string cityName);
		Task<City> GetByName(string cityName);
        Task<City> GetById(int cityId);
        public Task Update(City city);
	}
}
