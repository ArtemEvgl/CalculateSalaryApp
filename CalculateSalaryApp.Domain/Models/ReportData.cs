using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Models
{
    public struct ReportData
    {
		private int hour, pay;

		//todo: Добавить проверки
		public ReportData(int hour, int salary)
		{
			this.hour = hour;
			this.pay = salary;
		}

		
		
		public int Pay
		{
			get { return pay; }
		}

		public int Hour
		{
			get { return hour; }
		}

	}
}
