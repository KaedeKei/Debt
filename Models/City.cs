namespace Shedule.Models
{
	public class City
	{
		public int Id { get; set; }
        public string CityName { get; set; }

        public City(string cityName)
		{
			CityName = cityName;
		}

		public City()
		{
		}

		public override string ToString()
		{
			return this.CityName;
		}
	}
}
