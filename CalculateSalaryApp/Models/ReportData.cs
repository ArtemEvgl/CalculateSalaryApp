using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Models
{
    public struct ReportData
    {
		private int hour, salary;

		//todo: Добавить проверки
		public ReportData(int hour, int salary)
		{
			this.hour = hour;
			this.salary = salary;
		}

		
		
		public int Pay
		{
			get { return salary; }
		}

		public int Hour
		{
			get { return hour; }
		}

	}
}
