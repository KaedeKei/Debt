using Microsoft.EntityFrameworkCore;
using Shedule.Models;
using System.Collections;

namespace Shedule.Data
{
	public class SqliteSellersAsync : ISeller
	{
		private readonly AppDbContext _dbContext;

		public SqliteSellersAsync(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddSeller(Seller seller)
		{
			Seller? newSeller = await GetByName(seller.SellerName);
			if (newSeller == null)
			{
				await _dbContext.Sellers.AddAsync(seller);
				await _dbContext.SaveChangesAsync();
			}
			else
			{

			}
		}

		public async Task<IReadOnlyCollection<Seller>> GetSellers()
		{
			var list = await _dbContext.Sellers.ToListAsync();
			return list.AsReadOnly();
		}

        public async Task<IReadOnlyCollection<Seller>?> GetSellersByName(string sellerName)
        {
            var searchResults = _dbContext.Sellers.Where(it => it.SellerName.Contains(sellerName));
            var list = new List<Seller>();
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

        public async Task<Seller> GetByName(string sellerName)
		{
			var seller = await _dbContext.Sellers.FirstOrDefaultAsync(it => it.SellerName == sellerName);
			return seller;
		}

		public async Task<Seller> GetById(int Id)
		{
			var seller = await _dbContext.Sellers.FirstOrDefaultAsync(it => it.Id == Id);
			return seller;
		}

		public async Task<Seller> GetByINN(string inn)
		{
			var seller = await _dbContext.Sellers.FirstOrDefaultAsync(it => it.INN == inn);
			return seller;
		}


		public async Task Update(Seller seller)
		{
			_dbContext.Entry(seller).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
