using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Domain.Models
{
    public class TimeLog
    {
        public DateTime Date { get; set; }
        public string LastName { get; set; }
        public int WrokingHours { get; set; }
        public string Comment { get; set; }
    }
}
