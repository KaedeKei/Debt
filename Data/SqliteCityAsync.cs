using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using System.Collections;

namespace Shedule.Data
{
	public class SqliteCityAsync : ICity
	{
		private readonly AppDbContext _dbContext;

		public SqliteCityAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddCity(City city)
		{
            City? newCity = await GetByName(city.CityName);
			if (newCity == null)
			{
				await _dbContext.Cities.AddAsync(city);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

		public async Task<IReadOnlyCollection<City>> GetCities()
		{
			var list = await _dbContext.Cities.ToListAsync();
			return list.AsReadOnly();
		}

		public async Task<IReadOnlyCollection<City>?> GetCitiesByName(string cityName)
		{
			var searchResults = _dbContext.Cities.Where(it => (it.CityName.ToLower()).Contains(cityName.ToLower()));
			var list = new List<City>();
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

		public async Task<City> GetByName(string cityrName)
		{
			var city = await _dbContext.Cities.FirstOrDefaultAsync(it => it.CityName == cityrName);
			return city;
		}

		public async Task<City> GetById(int Id)
		{
			var city = await _dbContext.Cities.FirstAsync(it => it.Id == Id);
			return city;
		}

		
		public async Task Update(City city)
		{
			_dbContext.Entry(city).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
