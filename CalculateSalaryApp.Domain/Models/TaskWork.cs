using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
	public class TaskWork
	{
		private string descr;
		private int hour;
		private DateTime dateTime;

		
		public TaskWork(string descr, int hour, DateTime dateTime)
		{
			Description = descr;
			Hour = hour;
			DateTime = dateTime;
		}
		//TODO: добавить проверки для полей
		public string Description
		{
			get { return descr; }
			set { descr = value; }
		}		

		public int Hour
		{
			get { return hour; }
			set { hour = value; }
		}		

		public DateTime DateTime
		{
			get { return dateTime; }
			set { dateTime = value; }
		}

	}
}
