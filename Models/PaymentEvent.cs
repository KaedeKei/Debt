namespace Shedule.Models
{
	public class PaymentEvent
	{
		public int Id { get; set; }
		public int CustomerId { get; set; }
		public DateTime PaymentDate { get; set; }
		public double PaymentSumm { get; set; }
		public string PaymentText { get; set; }

		public PaymentEvent()
		{

		}

		public PaymentEvent(int customerId, DateTime paymentDate, double paymentSumm, string paymentText)
		{			
			CustomerId = customerId;
            PaymentDate = paymentDate;
            PaymentSumm = paymentSumm;
			PaymentText = paymentText;
		}
	}
}
