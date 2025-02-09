using System.ComponentModel.DataAnnotations;

namespace Shedule.Models
{
	public class Manager
	{
		public int Id { get; set; }
		public string ManagerName { get; set; }
		public string ManagerPassword { get; set; }
		public string ManagerStatus { get; set; }
		public bool IsEnable { get; set; }

		public Manager (string managerName, string managerPassword, string managerStatus, bool isEnable)
		{
			ManagerName = managerName;
			IsEnable = isEnable;
			ManagerPassword = managerPassword;
			ManagerStatus = managerStatus;
		}

		public Manager()
		{
		}

		public override string ToString()
		{
			return this.ManagerName;
		}
	}
}
