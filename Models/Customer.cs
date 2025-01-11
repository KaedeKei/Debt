namespace Shedule.Models
{
	public class Customer
	{
		public int Id { get; set; }
        public string CustomerName { get; set; }
        public string INN { get; set; }
        public int NumberOfPoints { get; set; }
		public int ResponsibleCityId { get; set; }
        public bool IsEnableForDownloadingPayments { get; set; }
        public bool IsEnable { get; set; }
		public int SellerId { get; set; }
		public int PaymentDeferment {  get; set; }

		public Customer(string customerName, string iNN, int numberOfPoints, int sellerId, int responsibleCityId, bool isEnableForDownloadingPayments, int paymentDeferment)
		{
			CustomerName = customerName;
			INN = iNN;
			NumberOfPoints = numberOfPoints;
			SellerId = sellerId;
			PaymentDeferment = paymentDeferment;
			ResponsibleCityId = responsibleCityId;
            IsEnableForDownloadingPayments = isEnableForDownloadingPayments;
			IsEnable = true;
		}

		public Customer()
		{
		}

		public override string ToString()
		{
			return this.CustomerName;
		}
	}
}
