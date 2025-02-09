using Shedule.Models;

namespace Shedule.Data
{
	public interface ISeller
    {
		public Task AddSeller(Seller seller);
        public Task<IReadOnlyCollection<Seller>> GetSellers();
        public Task<IReadOnlyCollection<Seller>> GetSellersByName(string sellerName);
        public Task<Seller> GetByName(string sellerName);
        public Task<Seller> GetById(int sellerId);
        public Task<Seller> GetByINN(string sellerInn);
        public Task Update(Seller seller);


	}
}
