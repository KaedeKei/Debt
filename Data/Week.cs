namespace Shedule.Data
{
	public class Week
	{
		public DateTime Monday { get; }
		public DateTime Tuesday { get; }
		public DateTime Wednesday { get; }
		public DateTime Thursday { get; }
		public DateTime Friday { get; }

		public Week()
		{
			Monday = new DateTime(2024, 02, 05);
			Tuesday = new DateTime(2024, 02, 06);
			Wednesday = new DateTime(2024, 02, 07);
			Thursday = new DateTime(2024, 02, 08);
			Friday = new DateTime(2024, 02, 09);
		}
	}
}
