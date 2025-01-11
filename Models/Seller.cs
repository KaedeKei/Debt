namespace Shedule.Models
{
	public class Seller
	{
		public int Id { get; set; }
        public string SellerName { get; set; }
        public string INN { get; set; }

        public Seller(string sellerName, string iNN)
		{
			SellerName = sellerName;
			INN = iNN;
		}

		public Seller()
		{
		}

		public override string ToString()
		{
			return this.SellerName;
		}
	}
}
