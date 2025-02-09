namespace Shedule.Models
{
	public class SaleEvent
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime SaleDate { get; set; }
		public double SaleSumm { get; set; }
		public string SaleName { get; set; }
        public int SaleCityId { get; set; }

        public SaleEvent()
		{

		}

		public SaleEvent(int customerId, DateTime saleDate, double saleSumm, string saleName, int saleCityId)
		{			
			CustomerId = customerId;
			SaleDate = saleDate;
			SaleSumm = saleSumm;
			SaleName = saleName;
			SaleCityId = saleCityId;
		}
	}
}
